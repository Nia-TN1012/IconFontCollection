#region Version info.
/**
*	@file IconFontItem.cs
*	@brief Represents a item of IconFont.
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

using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Represents a item of IconFont.
	/// </summary>
	public class IconFontItem : INotifyPropertyChanged {
		/// <summary>
		///		Gets the character code.
		/// </summary>
		public int CharacterCode { get; private set; }

		/// <summary>
		///		Gets the character code key.
		/// </summary>
		public string CodeKey =>
			$"U+{CharacterCode:X4}";

		/// <summary>
		///		Represents the value representing whether the registration to Favorites.
		/// </summary>
		private bool isFavorite = false;
		/// <summary>
		///		Gets and sets the value representing whether the registration to Favorites.
		/// </summary>
		public bool IsFavorite {
			get { return isFavorite; }
			set {
				if( isFavorite != value ) {
					isFavorite = value;
					NotifyPropertyChanged();
				}
			}
		}

		/// <summary>
		///		Creates a new instance of the IconFontItem class from the character code.
		/// </summary>
		/// <param name="code">Character code</param>
		public IconFontItem( int code ) {
			CharacterCode = code;
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
