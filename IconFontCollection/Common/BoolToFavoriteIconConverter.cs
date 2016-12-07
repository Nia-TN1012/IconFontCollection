#region Version info.
/**
*	@file BoolToFavoriteIconConverter.cs
*	@brief Provides the converters to convert a bool value for the favorites.
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
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides the method that converts a bool value to the character code of the favorite icon.
	/// </summary>
	public sealed class BoolToFavoriteIconContentConverter : IValueConverter {

		/// <summary>
		///		Converts a bool value to the character code of the favorite icon.
		/// </summary>
		/// <param name="value">Bool value</param>
		/// <param name="targetType">Target type ( Not using )</param>
		/// <param name="parameter">Parameter ( Not using )</param>
		/// <param name="language">Language ( Not using )</param>
		/// <returns>Character code of the favorite icon</returns>
		public object Convert( object value, Type targetType, object parameter, string language ) =>
			value is bool && ( bool )value ? '\uE735' : '\uE734';

		/// <summary>
		///		This method is not using. always returns null.
		/// </summary>
		public object ConvertBack( object value, Type targetType, object parameter, string language ) => null;
	}

	/// <summary>
	///		Provides the method that converts a bool value to the color of the favorite icon.
	/// </summary>
	public sealed class BoolToFavoriteIconColorConverter : IValueConverter {

		/// <summary>
		///		Represent the <see cref="Brush"/> of the target that is registered to favorites.
		/// </summary>
		private static readonly Brush FavoriteColor = new SolidColorBrush( Colors.Orange );

		/// <summary>
		///		Represent the <see cref="Brush"/> of the target that is not registered to favorites.
		/// </summary>
		private static readonly Brush NonFavoriteColor = new SolidColorBrush( Colors.Gray );

		/// <summary>
		///		Converts a bool value to the color of the favorite icon.
		/// </summary>
		/// <param name="value">Bool value</param>
		/// <param name="targetType">Target type ( Not using )</param>
		/// <param name="parameter">Parameter ( Not using )</param>
		/// <param name="language">Language ( Not using )</param>
		/// <returns>Color of the favorite icon</returns>
		public object Convert( object value, Type targetType, object parameter, string language ) =>
			value is bool && ( bool )value ? FavoriteColor : NonFavoriteColor;

		/// <summary>
		///		This method is not using. always returns null.
		/// </summary>
		public object ConvertBack( object value, Type targetType, object parameter, string language ) => null;
	}
}
