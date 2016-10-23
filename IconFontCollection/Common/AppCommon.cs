#region Version info.
/**
*	@file AppCommon.cs
*	@brief Provides the functions.
*
*	@par Version
*	1.1.0
*	@par Author
*	Nia Tomonaka
*	@par Copyright
*	Copyright (C) 2016 Chronoir.net
*	@par Created date
*	2016/10/23
*	@par Last update date
*	2016/10/23
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

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides the event argument with the confirmation message and the call back methods.
	/// </summary>
	public class ComfirmmationActionRunEventArgs : EventArgs {

		/// <summary>
		///		Gets the confirmation message.
		/// </summary>
		public string Message { get; private set; }

		/// <summary>
		///		Gets the call back methods.
		/// </summary>
		public Action Callback { get; private set; }

		/// <summary>
		///		Creates a new instance of the <see cref="ComfirmmationActionRunEventArgs"/> class from the confirmation message and the call back methods.
		/// </summary>
		/// <param name="mes">The confirmation message</param>
		/// <param name="cb">The call back methods</param>
		public ComfirmmationActionRunEventArgs( string mes, Action cb ) {
			Message = mes;
			Callback = cb;
		}
	}

	/// <summary>
	///		Represents the method that handles the <see cref="IComfirmationActionRun.ComfirmationActionRun"/> event.
	/// </summary>
	public delegate void ComfirmationActionRunEventHandler( object sender, ComfirmmationActionRunEventArgs e );

	/// <summary>
	///		Notifies clients that a confirmation action has run.
	/// </summary>
	public interface IComfirmationActionRun {

		/// <summary>
		///		Occurs when a confirmation action has run.
		/// </summary>
		event ComfirmationActionRunEventHandler ComfirmationActionRun;
	}
}
