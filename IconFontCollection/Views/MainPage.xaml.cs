using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

/// <summary>
///		IconFontCollection namespace
/// </summary>
namespace IconFontCollection {
	/// <summary>
	///		Main page
	/// </summary>
	public sealed partial class MainPage : Page {

		/// <summary>
		///		Creates a new instance of the MainPage class.
		/// </summary>
		public MainPage() {
			InitializeComponent();
		}

		/// <summary>
		///		Invoked when the transition from another page.
		/// </summary>
		/// <param name="e">Event arguments</param>
		protected override void OnNavigatedTo( NavigationEventArgs e ) {
			base.OnNavigatedTo( e );

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
		///		Invoked when user press SwitchIconFontCollectionViewButton button.
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
		///		Invoked when user press SwitchIconFontFavoritesViewButton button.
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
		///		Invoked when user press SwitchUserGuideButton button.
		/// </summary>
		private void SwitchUserGuideButton_Click( object sender, RoutedEventArgs e ) {
			IconFontPageContentFrame.Navigate( typeof( UserGuidePage ) );
			HamburgerButton.IsChecked = false;
		}

		/// <summary>
		///		Invoked when user press SwitchSettingAboutButton button.
		/// </summary>
		private void SwitchSettingAboutButton_Click( object sender, RoutedEventArgs e ) {
			IconFontPageContentFrame.Navigate( typeof( AppSettingView ) );
			HamburgerButton.IsChecked = false;
		}
	}
}
