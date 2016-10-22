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
		///		Get the sequence that contains the favorite IconFonts.
		/// </summary>
		public IEnumerable<IconFontItem> Items =>
			model.Items.Values.Where( _ => _.IsFavorite );

		/// <summary>
		///		Creates a new instance of the <see cref="IconFontFavoritesViewModel"/> class.
		/// </summary>
		public IconFontFavoritesViewModel() : base() {}
	}
}
