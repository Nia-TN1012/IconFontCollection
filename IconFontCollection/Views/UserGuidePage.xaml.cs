﻿using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides the user guide page.
	/// </summary>
	public sealed partial class UserGuidePage : Page {

		/// <summary>
		///		Creates a new instance of the <see cref="UserGuidePage"/> class.
		/// </summary>
		public UserGuidePage() {
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
	}
}
