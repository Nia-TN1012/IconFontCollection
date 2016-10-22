using System;
using System.Threading.Tasks;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides a view model of Main.
	/// </summary>
	class MainViewModel {

		/// <summary>
		///		Represents the <see cref="IconFontCollectionModel"/>.
		/// </summary>
		private IconFontCollectionModel model;

		/// <summary>
		///		Creates a new instance of the <see cref="MainViewModel"/> class.
		/// </summary>
		public MainViewModel() {
			// Gets the Model from the App object.
			model = ( App.Current as App )?.Model;
			if( model == null ) {
				throw new Exception( $"Failed to get reference of Model's instance on {GetType().ToString()}" );
			}
		}

		/// <summary>
		///		Initializes the model.
		/// </summary>
		public async Task InitializeModel() {
			await model.LoadFavoriteAsync();
		}
	}
}
