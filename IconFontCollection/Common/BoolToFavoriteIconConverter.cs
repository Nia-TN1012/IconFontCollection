﻿using System;
using System.Globalization;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

/// <summary>
///		IconFontCollection namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Converts the bool value to the character code of the favorite icon.
	/// </summary>
	public sealed class BoolToFavoriteIconContentConverter : IValueConverter {

		/// <summary>
		///		Converts the bool value to the character code of the favorite icon.
		/// </summary>
		/// <param name="value">Bool value</param>
		/// <param name="targetType">Target type ( Not using )</param>
		/// <param name="parameter">Parameter ( Not using )</param>
		/// <param name="language">Language ( Not using )</param>
		/// <returns>Character code of the favorite icon</returns>
		public object Convert( object value, Type targetType, object parameter, string language ) =>
			value is bool && ( bool )value ? char.ConvertFromUtf32( 0xE735 ) : char.ConvertFromUtf32( 0xE734 );

		/// <summary>
		///		This method is not using. always returns null.
		/// </summary>
		public object ConvertBack( object value, Type targetType, object parameter, string language ) => null;
	}

	/// <summary>
	///		Converts the bool value to the color of the favorite icon.
	/// </summary>
	public sealed class BoolToFavoriteIconColorConverter : IValueConverter {

		/// <summary>
		///		
		/// </summary>
		private static readonly Brush FavoriteColor = new SolidColorBrush( Colors.Orange );

		/// <summary>
		///		
		/// </summary>
		private static readonly Brush NonFavoriteColor = new SolidColorBrush( Colors.Gray );

		/// <summary>
		///		Converts the bool value to the color of the favorite icon.
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
