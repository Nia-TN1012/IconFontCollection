using System;
using System.Threading;
using System.Threading.Tasks;

namespace IconFontCollection {

	/// <summary>
	///		
	/// </summary>
	public sealed class AsyncLock {

		private readonly SemaphoreSlim semaphore = new SemaphoreSlim( 1, 1 );

		private readonly Task<IDisposable> releaser;

		public AsyncLock() {
			releaser = Task.FromResult( ( IDisposable )new Releaser( this ) );
		}

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

		private sealed class Releaser : IDisposable {

			private readonly AsyncLock toRelease;

			internal Releaser( AsyncLock _toRelease ) {
				toRelease = _toRelease;
			}

			public void Dispose() {
				toRelease.semaphore.Release();
			}
		}
	}
}
