#region Version info.
/**
*	@file IconFontViewModelBase.cs
*	@brief Provides a based view model of IconFont.
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides a based view model of IconFont.
	/// </summary>
	class IconFontViewModelBase : INotifyPropertyChanged {

		/// <summary>
		///		Represents the <see cref="IconFontCollectionModel"/>.
		/// </summary>
		protected IconFontCollectionModel model;

		/// <summary>
		///		Creates new instance of the <see cref="IconFontCollectionModel"/> class.
		/// </summary>
		public IconFontViewModelBase() {
			// Gets the model instance from the App object.
			model = ( App.Current as App )?.Model;
			if( model == null ) {
				throw new Exception( $"Failed to get reference of model instance on the {GetType().ToString()} class." );
			}

			model.PropertyChanged += Model_PropertyChanged;
		}

		/// <summary>
		///		Notifies when the model's property chenged.
		/// </summary>
		private void Model_PropertyChanged( object sender, PropertyChangedEventArgs e ) =>
			PropertyChanged?.Invoke( sender, e );

		/// <summary>
		///		Release all events of this class already registered in <see cref="IconFontCollectionModel"/>'s event handler.
		/// </summary>
		public void UnsubscribeAllEvents() {
			model.PropertyChanged -= Model_PropertyChanged;
		}

		/// <summary>
		///		The event handler to be generated after the property changes.
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>
		///		Notifies the property change that corresponds to the specified property name.
		/// </summary>
		/// <param name="propertyName">Property name</param>
		protected void NotifyPropertyChanged( [CallerMemberName]string propertyName = null ) {
			PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( propertyName ) );
		}

		/// <summary>
		///		Represents the instance of <see cref="SetFavoriteCommand"/>.
		/// </summary>
		private ICommand setFavorite;
		/// <summary>
		///		Gets the instance of <see cref="SetFavoriteCommand"/>.
		/// </summary>
		/// <remarks>The instance is delayed initialization.</remarks>
		public ICommand SetFavorite =>
			setFavorite ?? ( setFavorite = new SetFavoriteCommand( this ) );

		/// <summary>
		///		Provides a command to favorite registration and cancellation of the specified item.
		/// </summary>
		private class SetFavoriteCommand : ICommand {

			/// <summary>
			///		Represents the reference of <see cref="IconFontViewModelBase"/>.
			/// </summary>
			private IconFontViewModelBase viewModel;

			/// <summary>
			///		Creates the new instance of the <see cref="SetFavoriteCommand"/> class from the reference of <see cref="IconFontViewModelBase"/>.
			/// </summary>
			/// <param name="_viewModel">Reference of <see cref="IconFontViewModelBase"/></param>
			internal SetFavoriteCommand( IconFontViewModelBase _viewModel ) {
				viewModel = _viewModel;
				viewModel.PropertyChanged +=
					( sender, e ) =>
						CanExecuteChanged?.Invoke( sender, e );
			}

			/// <summary>
			///		Gets a value that indicates whether or not you can run the command.
			/// </summary>
			/// <param name="parameter">Parameter ( Not using )</param>
			/// <returns>Always returns true</returns>
			public bool CanExecute( object parameter ) => true;

			/// <summary>
			///		The event handler at the time of the change of the propriety of the command execution.
			/// </summary>
			public event EventHandler CanExecuteChanged;

			/// <summary>
			///		Runs the command to set the favorite registration and cancellation of the corresponding item.
			/// </summary>
			/// <param name="parameter">CodeKey</param>
			public void Execute( object parameter ) {
				var codeKey = parameter.ToString();
				if( viewModel.model.Items.ContainsKey( codeKey ) ) {
					viewModel.model.Items[codeKey].IsFavorite = !viewModel.model.Items[codeKey].IsFavorite;
				}
			}
		}
	}
}
