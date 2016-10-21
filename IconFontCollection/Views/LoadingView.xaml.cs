using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

/// <summary>
///		
/// </summary>
namespace IconFontCollection {
	/// <summary>
	///		それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
	/// </summary>
	public sealed partial class LoadingView : Page {

		/// <summary>
		///		
		/// </summary>
		public LoadingView() {
			InitializeComponent();
		}

		/// <summary>
		///		Invoked when the transition from another page.
		/// </summary>
		/// <param name="e">Event arguments</param>
		protected override void OnNavigatedTo( NavigationEventArgs e ) {
			base.OnNavigatedTo( e );

			loadingViewModel.InitializeModel();

			Frame.Navigate( typeof( MainPage ) );			
		}
	}
}
