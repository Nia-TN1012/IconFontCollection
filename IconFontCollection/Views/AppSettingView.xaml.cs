using System;
using Windows.ApplicationModel.Resources;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides the page for application setting.
	/// </summary>
	public sealed partial class AppSettingView : Page {

		/// <summary>
		///		Creates a new instance of the <see cref="AppSettingView"/> class.
		/// </summary>
		public AppSettingView() {
			InitializeComponent();
		}

		/// <summary>
		///		Invoked when the transition from another page.
		/// </summary>
		/// <param name="e">Event arguments</param>
		protected override void OnNavigatedTo( NavigationEventArgs e ) {
			base.OnNavigatedTo( e );

			// Get the current View, to display the Back button, and stores the events of when you press the button.
			var currentView = SystemNavigationManager.GetForCurrentView();
			currentView.AppViewBackButtonVisibility =
				Frame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
			currentView.BackRequested += Page_BackRequested;
		}

		/// <summary>
		///		Invoked when the transition to another page.
		/// </summary>
		/// <param name="e">Event arguments</param>
		protected override void OnNavigatingFrom( NavigatingCancelEventArgs e ) {
			base.OnNavigatingFrom( e );

			// When this page go back to the caller, delete the event handler.
			if( e.NavigationMode == NavigationMode.Back ) {
				var currentView = SystemNavigationManager.GetForCurrentView();
				currentView.BackRequested -= Page_BackRequested;
			}
		}

		/// <summary>
		///		Invoked when the Back button is pressed.
		/// </summary>
		private void Page_BackRequested( object sender, BackRequestedEventArgs e ) {
			if( Frame.CanGoBack ) {
				Frame.GoBack();
				e.Handled = true;
			}
		}

		/// <summary>
		///		Invoke when the confirmation action has run.
		/// </summary>
		private async void AppSettingViewModel_ComfirmationActionRun( object sender, ComfirmmationActionRunEventArgs e ) {
			var resource = ResourceLoader.GetForCurrentView();

			var confirmDialog = new MessageDialog( e.Message, resource.GetString( "ConfrimDialogTitle" ) );
			confirmDialog.Commands.Add( new UICommand( resource.GetString( "ConfrimDialogYes" ) ) );
			confirmDialog.Commands.Add( new UICommand( resource.GetString( "ConfrimDialogNo" ) ) );
			confirmDialog.DefaultCommandIndex = 1;

			var result = await confirmDialog.ShowAsync();
			if( result.Label == resource.GetString( "ConfrimDialogYes" ) ) {
				e.Callback?.Invoke();
			}
		}
	}
}
