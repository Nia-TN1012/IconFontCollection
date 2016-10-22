using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.ApplicationModel;

/// <summary>
///		IconFontCollection namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides a view model of AppSetting.
	/// </summary>
	class AppSettingViewModel : INotifyPropertyChanged {

		/// <summary>
		///		Represents the IconFontCollectionModel.
		/// </summary>
		private IconFontCollectionModel model;

		/// <summary>
		///		Represents the package information.
		/// </summary>
		private PackageId packageInfo;

		/// <summary>
		///		Gets the current version.
		/// </summary>
		public string CurrentVersion =>
			packageInfo != null ? $"{packageInfo?.Version.Major}.{packageInfo.Version.Minor}.{packageInfo.Version.Build}" : "";

		/// <summary>
		///		Creates a new instance of the AppSettingViewModel class.
		/// </summary>
		public AppSettingViewModel() {
			// Gets the Model from the App object.
			model = ( App.Current as App )?.Model;
			if( model == null ) {
				throw new Exception( $"Failed to get reference of Model's instance on {GetType().ToString()}" );
			}

			model.PropertyChanged +=
				( sender, e ) => {
					PropertyChanged?.Invoke( sender, e );
				};

			packageInfo = Package.Current.Id;
		}

		/// <summary>
		///		The event handler to be generated after the property changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///		Notifies the property change that corresponds to the specified property name.
		/// </summary>
		/// <param name="propertyName">Property name</param>
		private void NotifyPropertyChanged( [CallerMemberName]string propertyName = null ) {
			PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
		}

		/// <summary>
		///		Represents the instance of ClearAllFavoritesCommand.
		/// </summary>
		private ICommand clearAllFavorites;
		/// <summary>
		///		Gets the instance of ClearAllFavoritesCommand.
		/// </summary>
		/// <remarks>The instance is delayed initialization.</remarks>
		public ICommand ClearAllFavorites =>
			clearAllFavorites ?? ( clearAllFavorites = new ClearAllFavoritesCommand( this ) );

		/// <summary>
		///		Provides a command to clear all registered favorite IconFonts.
		/// </summary>
		private class ClearAllFavoritesCommand : ICommand {

			/// <summary>
			///		Represents the reference ViewModel.
			/// </summary>
			private AppSettingViewModel viewModel;

			/// <summary>
			///		Creates a new instance of the ClearAllFavoriteCommand class from the reference ViewModel.
			/// </summary>
			/// <param name="_viewModel">Reference ViewModel</param>
			internal ClearAllFavoritesCommand( AppSettingViewModel _viewModel ) {
				viewModel = _viewModel;
				viewModel.PropertyChanged +=
					( sender, e ) => {
						CanExecuteChanged?.Invoke( sender, e );
					};
			}

			/// <summary>
			///		Gets the value that indicates whether or not you can run the command.
			/// </summary>
			/// <param name="parameter">Parameter ( Not using )</param>
			/// <returns>Always returns true</returns>
			public bool CanExecute( object parameter ) => true;

			/// <summary>
			///		The event handler at the time of the change of the propriety of the command execution.
			/// </summary>
			public event EventHandler CanExecuteChanged;

			/// <summary>
			///		Run the command to clear all registered favorite IconFonts.
			/// </summary>
			/// <param name="parameter">Parameter ( Not using )</param>
			public void Execute( object parameter ) {
				viewModel.model.ClearAllFavorites();
			}
		}
	}
}
