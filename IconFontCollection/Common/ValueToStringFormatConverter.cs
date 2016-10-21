﻿using System;
using System.Globalization;
using Windows.UI.Xaml.Data;

/// <summary>
///		IconFontCollection namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		This converter class provides methods whitch converts the value in accordance with the specified format and culture information.
	/// </summary>
	public sealed class ValueToStringFormatConverter : IValueConverter {

		/// <summary>
		///		This method converts the value in accordance with the specified format and culture information.
		/// </summary>
		/// <param name="value">Source value</param>
		/// <param name="targetType">Target type</param>
		/// <param name="parameter">Format string</param>
		/// <param name="language">Culture information</param>
		/// <returns>String that has been converted by the format and culture information</returns>
		public object Convert( object value, Type targetType, object parameter, string language ) {
			// Using Format and Culture infomation
			if( parameter != null && parameter is string && language != null ) {
				return string.Format( new CultureInfo( language ), ( string )parameter, value );
			}
			// Using Format only
			else if( parameter != null && parameter is string ) {
				return ( ( DateTime )value ).ToString( parameter.ToString() );
			}
			// Using Culture infomation only
			else if( language != null ) {
				return ( ( DateTime )value ).ToString( new CultureInfo( language ) );
			}
			// Default
			return value;
		}

		/// <summary>
		///		This method is not using. always returns null.
		/// </summary>
		public object ConvertBack( object value, Type targetType, object parameter, string language ) => null;
	}

	/// <summary>
	///		This converter class provides methods whitch converts the value in accordance with the specified format and culture information.
	/// </summary>
	public sealed class ValueToFontIconGlyphConverter : IValueConverter {

		/// <summary>
		///		This method converts the value in accordance with the specified format and culture information.
		/// </summary>
		/// <param name="value">Source value</param>
		/// <param name="targetType">Target type</param>
		/// <param name="parameter">Format string</param>
		/// <param name="language">Culture information</param>
		/// <returns>String that has been converted by the format and culture information</returns>
		public object Convert( object value, Type targetType, object parameter, string language ) {
			if( value != null && value is int ) {
				return char.ConvertFromUtf32( ( int )value );
			}
			return value;
		}

		/// <summary>
		///		This method is not using. always returns null.
		/// </summary>
		public object ConvertBack( object value, Type targetType, object parameter, string language ) => null;
	}
}
