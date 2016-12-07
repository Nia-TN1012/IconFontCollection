#region Version info.
/**
*	@file MainPage.xaml.cs
*	@brief Provides the main page.
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

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides the main page.
	/// </summary>
	public sealed partial class MainPage : Page {

		/// <summary>
		///		Creates a new instance of the <see cref="MainPage"/> class.
		/// </summary>
		public MainPage() {
			InitializeComponent();
		}

		/// <summary>
		///		Invoked when the transition from another page.
		/// </summary>
		/// <param name="e">Event arguments</param>
		protected override async void OnNavigatedTo( NavigationEventArgs e ) {
			base.OnNavigatedTo( e );

			await mainViewModel.InitializeModel();

			IconFontPageContentFrame.Navigate( typeof( IconFontCollectionView ) );
		}

		/// <summary>
		///		Invoked when the navigation occurs in Frame in SplitView.
		/// </summary>
		private void IconFontPageContentFrame_Navigated( object sender, NavigationEventArgs e ) {
			if( e.SourcePageType != null ) {
				// Check the radio button that corresponds to the page type name.
				switch( e.SourcePageType.Name ) {
					case nameof( IconFontCollectionView ):
						SwitchIconFontCollectionViewButton.IsChecked = true;
						break;
					case nameof( IconFontFavotitesView ):
						SwitchIconFontFavoritesViewButton.IsChecked = true;
						break;
					case nameof( UserGuidePage ):
						SwitchUserGuideButton.IsChecked = true;
						break;
					case nameof( AppSettingView ):
						SwitchSettingAboutButton.IsChecked = true;
						break;
				}
			}
		}

		/// <summary>
		///		Invoked when user press <see cref="SwitchIconFontCollectionViewButton"/> button.
		/// </summary>
		private void SwitchIconFontCollectionViewButton_Click( object sender, RoutedEventArgs e ) {
			// When the current page is the collection view ...
			// ※Satisfy the condition is of the if statement, but only when the current page is of the collection view.
			if( !IconFontPageContentFrame.CanGoBack ) {
				( IconFontPageContentFrame.Content as IconFontCollectionView )?.GridViewJumpToFirstItem();
			}
			// From the collection view page when, it has been a transition to another page
			else {
				while( IconFontPageContentFrame.CanGoBack ) {
					IconFontPageContentFrame.GoBack();
				}
			}
			HamburgerButton.IsChecked = false;
		}

		/// <summary>
		///		Invoked when user press <see cref="SwitchIconFontFavoritesViewButton"/> button.
		/// </summary>
		private void SwitchIconFontFavoritesViewButton_Click( object sender, RoutedEventArgs e ) {
			var iconFontFavoritesView = IconFontPageContentFrame.Content as IconFontFavotitesView;
			if( iconFontFavoritesView != null ) {
				iconFontFavoritesView.GridViewJumpToFirstItem();
			}
			else {
				IconFontPageContentFrame.Navigate( typeof( IconFontFavotitesView ) );
			}
			HamburgerButton.IsChecked = false;
		}

		/// <summary>
		///		Invoked when user press <see cref="SwitchUserGuideButton"/> button.
		/// </summary>
		private void SwitchUserGuideButton_Click( object sender, RoutedEventArgs e ) {
			IconFontPageContentFrame.Navigate( typeof( UserGuidePage ) );
			HamburgerButton.IsChecked = false;
		}

		/// <summary>
		///		Invoked when user press <see cref=" SwitchSettingAboutButton"/> button.
		/// </summary>
		private void SwitchSettingAboutButton_Click( object sender, RoutedEventArgs e ) {
			IconFontPageContentFrame.Navigate( typeof( AppSettingView ) );
			HamburgerButton.IsChecked = false;
		}
	}
}
