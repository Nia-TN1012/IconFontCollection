#region Version info.
/**
*	@file MainViewModel.cs
*	@brief Provides a view model of Main.
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
			// Gets the model instance from the App object.
			model = ( App.Current as App )?.Model;
			if( model == null ) {
				throw new Exception( $"Failed to get reference of model instance on the {GetType().ToString()} class." );
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
