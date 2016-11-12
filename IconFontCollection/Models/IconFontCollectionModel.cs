#region Version info.
/**
*	@file IconFontCollectionModel.cs
*	@brief Provide a model of IconFontCollection.
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
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Windows.Storage;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provide a model of IconFontCollection.
	/// </summary>
	public class IconFontCollectionModel : INotifyPropertyChanged {

		/// <summary>
		///		Represents the application's local folder.
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
		///		Represents the sequence of the registered favorites loaded from local.
		/// </summary>
		private IEnumerable<string> registeredFavoritesLocal;

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
						registeredFavoritesLocal = await FileIO.ReadLinesAsync( ( IStorageFile )localFile );
						foreach( var codeKey in registeredFavoritesLocal ) {
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
		///		Saves the registered favorite list to local file.
		/// </summary>
		public async Task SaveFavoriteList() {
			try {
				var registeredFavorites = Items.Where( _ => _.Value.IsFavorite ).Select( _ => _.Key );
				if( !registeredFavorites.SequenceEqual( registeredFavoritesLocal ?? Enumerable.Empty<string>() ) ) {
					using( await locker.LockAsync() ) {
						var localFile = await localFolder.CreateFileAsync( favoriteFilename, CreationCollisionOption.ReplaceExisting );
						await FileIO.WriteLinesAsync( localFile, registeredFavorites );
					}
				}
			}
			catch( Exception ) {}
		}

		/// <summary>
		///		Waits until all file I/O completion.
		/// </summary>
		public async Task WaitFileIOAsync() {
			using( await locker.LockAsync() ) {
				return;
			}
		}

		/// <summary>
		///		Clears all registered favorite IconFonts.
		/// </summary>
		public void ClearAllFavorites() {
			foreach( var item in Items ) {
				item.Value.IsFavorite = false;
			}
		}

		/// <summary>
		///		Restores the favorites from local.
		/// </summary>
		public void RestoreLocalFavorites() {
			ClearAllFavorites();
			var registeredFavorites = Items.Where( _ => _.Value.IsFavorite ).Select( _ => _.Key );
			if( registeredFavoritesLocal != null && !registeredFavorites.SequenceEqual( registeredFavoritesLocal ) ) {
				foreach( var codeKey in registeredFavoritesLocal ) {
					Items[codeKey].IsFavorite = true;
				}
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
