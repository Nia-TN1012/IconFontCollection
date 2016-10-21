using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
///		IconFontCollection namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides a view model of AppSetting.
	/// </summary>
	class LoadingViewModel : INotifyPropertyChanged {

		/// <summary>
		///		IconFontCollectionModel
		/// </summary>
		private IconFontCollectionModel model;

		/// <summary>
		///		Creates a new instance of the AppSettingViewModel class.
		/// </summary>
		public LoadingViewModel() {
			// Gets the Model from the App object.
			model = ( App.Current as App )?.Model;
			if( model == null ) {
				throw new Exception( $"Failed to get reference of Model's instance on {GetType().ToString()}" );
			}

			model.PropertyChanged +=
				( sender, e ) => {
					PropertyChanged?.Invoke( sender, e );
				};
		}

		/// <summary>
		///		
		/// </summary>
		public void InitializeModel() {
			model.Initialize();
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
	}
}
