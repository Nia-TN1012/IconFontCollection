#region Version info.
/**
*	@file IconFontCollectionViewModel.cs
*	@brief Represents a group item of IconFonts.
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
	///		Represents a group item of IconFonts.
	/// </summary>
	class IconFontCollectionGroup {
		/// <summary>
		///		Gets and sets the Group name.
		/// </summary>
		public string GroupTitle { get; set; }

		/// <summary>
		///		Gets and sets the Group items.
		/// </summary>
		public IEnumerable<IconFontItem> Items { get; set; }
	}

	/// <summary>
	///		Provides a view model of IconFontCollection.
	/// </summary>
	class IconFontCollectionViewModel : IconFontViewModelBase {

		/// <summary>
		///		Gets the sequence that contains the group of IconFonts.
		/// </summary>
		public IEnumerable<IconFontCollectionGroup> Items { get; private set; }

		/// <summary>
		///		Creates a new instance of the <see cref="IconFontCollectionViewModel"/> class.
		/// </summary>
		public IconFontCollectionViewModel() : base() {
			Items = model.Items.Values
						.GroupBy( _ => _.CharacterCode / 0x100 )
						.Select( _ => new IconFontCollectionGroup {
							GroupTitle = $"U+{( _.Key * 0x100 ):X4} - U+{( _.Key * 0x100 + 0xFF ):X4}",
							Items = _.AsEnumerable()
						} );
		}
	}
}
