using System.ComponentModel;
using System.Runtime.CompilerServices;

/// <summary>
///		IconFontCollection namespace
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
