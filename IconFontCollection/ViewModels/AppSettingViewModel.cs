#region Version info.
/**
*	@file AppSettingViewModel.cs
*	@brief Provides a view model of AppSetting.
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Resources;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides a view model of AppSetting.
	/// </summary>
	class AppSettingViewModel : INotifyPropertyChanged, IComfirmationActionRun {

		/// <summary>
		///		Represents the <see cref="IconFontCollectionModel"/>.
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
		///		Creates a new instance of the <see cref="AppSettingViewModel"/> class.
		/// </summary>
		public AppSettingViewModel() {
			// Gets the model instance from the App object.
			model = ( App.Current as App )?.Model;
			if( model == null ) {
				throw new Exception( $"Failed to get reference of model instance on the {GetType().ToString()} class." );
			}

			model.PropertyChanged +=
				( sender, e ) => {
					PropertyChanged?.Invoke( sender, e );
				};

			packageInfo = Package.Current.Id;
		}

		/// <summary>
		///		The event handler to be generated after the confirmation action has run.
		/// </summary>
		public event ComfirmationActionRunEventHandler ComfirmationActionRun;

		/// <summary>
		///		The event handler to be generated after the property has changed.
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
		///		Represents the instance of <see cref="ClearAllFavoritesCommand"/>.
		/// </summary>
		private ICommand clearAllFavorites;
		/// <summary>
		///		Gets the instance of <see cref="ClearAllFavoritesCommand"/>.
		/// </summary>
		/// <remarks>The instance is delayed initialization.</remarks>
		public ICommand ClearAllFavorites =>
			clearAllFavorites ?? ( clearAllFavorites = new ClearAllFavoritesCommand( this ) );

		/// <summary>
		///		Represents the instance of <see cref="RestoreLocalFavoritesCommand"/>.
		/// </summary>
		private ICommand restoreLocalFavorites;
		/// <summary>
		///		Gets the instance of <see cref="RestoreLocalFavoritesCommand"/>.
		/// </summary>
		/// <remarks>The instance is delayed initialization.</remarks>
		public ICommand RestoreLocalFavorites =>
			restoreLocalFavorites ?? ( restoreLocalFavorites = new RestoreLocalFavoritesCommand( this ) );

		/// <summary>
		///		Provides a command to clear all registered favorite IconFonts.
		/// </summary>
		private class ClearAllFavoritesCommand : ICommand {

			/// <summary>
			///		Represents the reference <see cref="AppSettingViewModel"/>.
			/// </summary>
			private AppSettingViewModel viewModel;

			/// <summary>
			///		Creates a new instance of the <see cref="ClearAllFavoritesCommand"/> class from the reference <see cref="AppSettingViewModel"/>.
			/// </summary>
			/// <param name="_viewModel">Reference <see cref="AppSettingViewModel"/></param>
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
				var resource = ResourceLoader.GetForCurrentView();
				viewModel.ComfirmationActionRun?.Invoke(
					viewModel,
					new ComfirmmationActionRunEventArgs(
						resource.GetString( "ConfrimDialogCleasrFavorites" ),
						viewModel.model.ClearAllFavorites
					)
				);
			}
		}

		/// <summary>
		///		Provides a command to restore the favorites from local.
		/// </summary>
		private class RestoreLocalFavoritesCommand : ICommand {

			/// <summary>
			///		Represents the reference <see cref="AppSettingViewModel"/>.
			/// </summary>
			private AppSettingViewModel viewModel;

			/// <summary>
			///		Creates a new instance of the <see cref="RestoreLocalFavoritesCommand"/> class from the reference <see cref="AppSettingViewModel"/>.
			/// </summary>
			/// <param name="_viewModel">Reference <see cref="AppSettingViewModel"/></param>
			internal RestoreLocalFavoritesCommand( AppSettingViewModel _viewModel ) {
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
			///		Runs the command to restore the favorites from local.
			/// </summary>
			/// <param name="parameter">Parameter ( Not using )</param>
			public void Execute( object parameter ) {
				var resource = ResourceLoader.GetForCurrentView();
				viewModel.ComfirmationActionRun?.Invoke(
					viewModel,
					new ComfirmmationActionRunEventArgs(
						resource.GetString( "ConfrimDialogRestoreFavorites" ),
						viewModel.model.RestoreLocalFavorites
					)
				);
			}
		}
	}
}
