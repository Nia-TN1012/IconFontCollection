#region Version info.
/**
*	@file IconFontFavoritesViewModel.cs
*	@brief Provides a view model of IconFontFavorites.
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

using System.Collections.Generic;
using System.Linq;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides a view model of IconFontFavorites.
	/// </summary>
	class IconFontFavoritesViewModel : IconFontViewModelBase {

		/// <summary>
		///		Gets the sequence that contains the favorite IconFonts.
		/// </summary>
		public IEnumerable<IconFontItem> Items =>
			model.Items.Values.Where( _ => _.IsFavorite );

		/// <summary>
		///		Creates a new instance of the <see cref="IconFontFavoritesViewModel"/> class.
		/// </summary>
		public IconFontFavoritesViewModel() : base() {}
	}
}
