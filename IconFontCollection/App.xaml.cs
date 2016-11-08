#region Version info.
/**
*	@file App.xaml.cs
*	@brief Provides application-specific behavior to supplement the default Application class.
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
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides application-specific behavior to supplement the default Application class.
	/// </summary>
	sealed partial class App : Application {

		/// <summary>
		///		Gets the <see cref="IconFontCollectionModel"/> instance.
		/// </summary>
		public IconFontCollectionModel Model { get; }

		/// <summary>
		///		Initializes the singleton application object.  This is the first line of authored code
		///		executed, and as such is the logical equivalent of main() or WinMain().
		/// </summary>
		public App() {
			InitializeComponent();
			Suspending += OnSuspending;

			Model = new IconFontCollectionModel();

#if DEBUG
			// Change language for Debugging of additional languages.
			System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo( "zh-TW" );
#endif
		}

		/// <summary>
		///		Invoked when the application is launched normally by the end user. Other entry points
		///		will be used such as when the application is launched to open a specific file.
		/// </summary>
		/// <param name="e">Details about the launch request and process.</param>
		protected override void OnLaunched( LaunchActivatedEventArgs e ) {
#if DEBUG
			if( System.Diagnostics.Debugger.IsAttached ) {
				DebugSettings.EnableFrameRateCounter = true;
			}
#endif
			Frame rootFrame = Window.Current.Content as Frame;

			// Do not repeat app initialization when the Window already has content,
			// just ensure that the window is active
			if( rootFrame == null ) {
				// Create a Frame to act as the navigation context and navigate to the first page
				rootFrame = new Frame();

				rootFrame.NavigationFailed += OnNavigationFailed;

				if( e.PreviousExecutionState == ApplicationExecutionState.Terminated ) {
					//TODO: Load state from previously suspended application
				}

				// Place the frame in the current Window
				Window.Current.Content = rootFrame;
			}

			if( e.PrelaunchActivated == false ) {
				if( rootFrame.Content == null ) {
					// When the navigation stack isn't restored navigate to the first page,
					// configuring the new page by passing required information as a navigation
					// parameter
					rootFrame.Navigate( typeof( MainPage ), e.Arguments );
				}
				// Ensure the current window is active
				Window.Current.Activate();
			}
		}

		/// <summary>
		///		Invoked when Navigation to a certain page fails
		/// </summary>
		/// <param name="sender">The Frame which failed navigation</param>
		/// <param name="e">Details about the navigation failure</param>
		void OnNavigationFailed( object sender, NavigationFailedEventArgs e ) {
			throw new Exception( "Failed to load Page " + e.SourcePageType.FullName );
		}

		/// <summary>
		///		Invoked when application execution is being suspended.  Application state is saved
		///		without knowing whether the application will be terminated or resumed with the contents
		///		of memory still intact.
		/// </summary>
		/// <param name="sender">The source of the suspend request.</param>
		/// <param name="e">Details about the suspend request.</param>
		private async void OnSuspending( object sender, SuspendingEventArgs e ) {
			var deferral = e.SuspendingOperation.GetDeferral();
			//TODO: Save application state and stop any background activity

			await Model.SaveFavoriteList();
			await Model.WaitFileIOAsync();

			deferral.Complete();
		}
	}
}
