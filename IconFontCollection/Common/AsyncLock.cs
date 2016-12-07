#region Version info.
/**
*	@file AsyncLock.cs
*	@brief Provides the function of exclusive control of asynchronous processing using the "using" statement.
*
*	@par Version
*	1.2.4
*	@par Author
*	Nia Tomonaka
*	@par Copyright
*	Copyright (C) 2016 Chronoir.net
*	@par Created date
*	2016/10/23
*	@par Last update date
*	2016/12/07
*	@par Licence
*	BSD Licence（ 2-caluse ）
*	@par Contact
*	@@nia_tn1012（ https://twitter.com/nia_tn1012/ ）
*	@par Homepage
*	- http://chronoir.net/ ( Homepage )
*	- https://github.com/Nia-TN1012/IconFontCollection ( GitHub )
*/
#endregion

using System;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides the function of exclusive control of asynchronous processing using the "using" statement.
	/// </summary>
	public sealed class AsyncLock {

		/// <summary>
		///		Represents the <see cref="SemaphoreSlim"/> to lock.
		/// </summary>
		private readonly SemaphoreSlim semaphore = new SemaphoreSlim( 1, 1 );

		/// <summary>
		///		Represents the <see cref="IDisposable"/> object that can unlock the <see cref="SemaphoreSlim"/>.
		/// </summary>
		private readonly Task<IDisposable> releaser;

		/// <summary>
		///		Creates a new instance of the <see cref="AsyncLock"/> class.
		/// </summary>
		public AsyncLock() {
			releaser = Task.FromResult( ( IDisposable )new Releaser( this ) );
		}

		/// <summary>
		///		<para>Asynchronously waits to enter the <see cref="SemaphoreSlim"/> .</para>
		///		<para>After waiting, returns IDisposable object that can unlock the <see cref="SemaphoreSlim"/>.</para>
		/// </summary>
		/// <returns><see cref="IDisposable"/> object that can unlock the <see cref="SemaphoreSlim"/></returns>
		/// <example>
		///		<code>
		///			AsyncLock locker = new AsyncLock();
		///			using( await locker.LockAsync() ) {
		///				// the Semaphone of locker is locked.
		///			}
		///			// the Semaphone of locker is unlocked.
		///		</code>
		/// </example>
		public Task<IDisposable> LockAsync() {
			var wait = semaphore.WaitAsync();
			return wait.IsCompleted ?
					releaser :
					wait.ContinueWith(
						( _, state ) => ( IDisposable )state,
						releaser.Result,
						CancellationToken.None,
						TaskContinuationOptions.ExecuteSynchronously,
						TaskScheduler.Default
					);
		}

		/// <summary>
		///		Provides a <see cref="IDisposable"/> object that can unlock the <see cref="SemaphoreSlim"/>.
		/// </summary>
		private sealed class Releaser : IDisposable {

			/// <summary>
			///		Represents the reference of <see cref="AsyncLock"/>.
			/// </summary>
			private readonly AsyncLock toRelease;

			/// <summary>
			///		Creates a new instance of the <see cref="Releaser"/> class from the reference of <see cref="AsyncLock"/>.
			/// </summary>
			/// <param name="_toRelease">Reference of <see cref="AsyncLock"/></param>
			internal Releaser( AsyncLock _toRelease ) {
				toRelease = _toRelease;
			}

			/// <summary>
			///		Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
			/// </summary>
			public void Dispose() {
				toRelease.semaphore.Release();
			}
		}
	}
}
