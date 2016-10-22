using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Storage;

/// <summary>
///		IconFontCollection namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provide a model of IconFontCollection.
	/// </summary>
	public class IconFontCollectionModel : INotifyPropertyChanged {

		/// <summary>
		///		Represents the folder of local.
		/// </summary>
		private static readonly StorageFolder localFolder = ApplicationData.Current.LocalFolder;

		/// <summary>
		///		Represents the file name of registered favorite list.
		/// </summary>
		private const string favoriteFilename = "favorite.dat";

		/// <summary>
		///		Represents the lock object for async.
		/// </summary>
		private static AsyncLock locker = new AsyncLock();

		/// <summary>
		///		Gets the dictionary list that contains IconFonts.
		/// </summary>
		public Dictionary<string, IconFontItem> Items { get; private set; }

		/// <summary>
		///		Creates a new instance of the IconFontCollectionModel class.
		/// </summary>
		public IconFontCollectionModel() {
			Items = new Dictionary<string, IconFontItem>();
			foreach( var codes in SegoeMDL2AssetsValidCodeList.CharacterCodesList ) {
				for( int code = codes.Start; code <= codes.End; code++ ) {
					var item = new IconFontItem( code );
					Items[item.CodeKey] = item;
				}
			}
		}

		/// <summary>
		///		Load registered favorite list from local file.
		/// </summary>
		public async Task LoadFavoriteAsync() {
			try {
				using( await locker.LockAsync() ) {
					var localFile = await localFolder.TryGetItemAsync( favoriteFilename );
					if( localFile != null && localFile is IStorageFile ) {
						foreach( var codeKey in await FileIO.ReadLinesAsync( ( IStorageFile )localFile ) ) {
							if( Items.ContainsKey( codeKey ) ) {
								Items[codeKey].IsFavorite = true;
							}
						}
					}
				}
			}
			catch( Exception ) {}
		}

		/// <summary>
		///		Save registered favorite list to local file.
		/// </summary>
		public async Task SaveFavoriteList() {
			try {
				using( await locker.LockAsync() ) {
					var localFile = await localFolder.CreateFileAsync( favoriteFilename, CreationCollisionOption.ReplaceExisting );
					await FileIO.WriteLinesAsync( localFile, Items.Where( _ => _.Value.IsFavorite ).Select( _ => _.Key ) );
				}
			}
			catch( Exception ) {}
		}

		/// <summary>
		///		Wait until all file I/O completion.
		/// </summary>
		public async Task WaitFileIOAsync() {
			using( await locker.LockAsync() ) {
				return;
			}
		}

		/// <summary>
		///		Clear all registered favorite IconFonts.
		/// </summary>
		public void ClearAllFavorites() {
			foreach( var item in Items ) {
				item.Value.IsFavorite = false;
			}
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
