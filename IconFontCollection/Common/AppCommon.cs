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
