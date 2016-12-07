#region Version info.
/**
*	@file ValueToStringFormatConverter.cs
*	@brief Provides the converters to convert a value for the character code.
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
using System.Globalization;
using Windows.UI.Xaml.Data;

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Provides the method whitch converts a value in accordance with the specified format and culture information.
	/// </summary>
	public sealed class ValueToStringFormatConverter : IValueConverter {

		/// <summary>
		///		Converts a value in accordance with the specified format and culture information.
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
	///		Provides the method whitch converts a value to the <see cref="Windows.UI.Xaml.Controls.FontIcon.Glyph"/> of <see cref="Windows.UI.Xaml.Controls.FontIcon"/>.
	/// </summary>
	public sealed class ValueToFontIconGlyphConverter : IValueConverter {

		/// <summary>
		///		Converts a value to the <see cref="Windows.UI.Xaml.Controls.FontIcon.Glyph"/> of <see cref="Windows.UI.Xaml.Controls.FontIcon"/>.
		/// </summary>
		/// <param name="value">Source value</param>
		/// <param name="targetType">Target type</param>
		/// <param name="parameter">Format string</param>
		/// <param name="language">Culture information</param>
		/// <returns><see cref="Windows.UI.Xaml.Controls.FontIcon.Glyph"/> of <see cref="Windows.UI.Xaml.Controls.FontIcon"/></returns>
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
