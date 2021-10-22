# IconFontCollection

![app_promote.png](https://raw.githubusercontent.com/Nia-TN1012/IconFontCollection/master/Image/app_promote.png)

**Please to accompany UWP applications development!**

IconFont Collection displays a list of icon fonts for development of UWP Applications.

![home.png](https://raw.githubusercontent.com/Nia-TN1012/IconFontCollection/master/Image/en-US/home.png)

## Application summary

|||
|---|---|
|Application name|IconFont Collection|
|Version|1.2.2|
|Developer|Nia Tomonaka (@nia_tn1012)|
|Released day|October 23, 2016|
|Last updated day|November 15, 2016|
|Available on|Windows 11 / Windows 10 / Windows 10 Mobile (Build 10240 or later)|
|Using capabilities|Nothing|
|Language supported|Japanese (ja, ja-JP), English (en, en-US), German (de, de-DE), French (fr, fr-FR), Italian (it, it-IT), Chinese (zh-CN, zh-TW)|
|Licence|BSD Licence (2-clause)|
|Blog article|[https://chronoir.net/iconfont-collection/](https://chronoir.net/iconfont-collection/)|
|GitHub|[https://github.com/Nia-TN1012/IconFontCollection](https://github.com/Nia-TN1012/IconFontCollection)|
|Programing languages / Frameworks|C# / XAML / .NET Core / .NET Framework / Windows 10 SDK|
|Libraries|Nothing|
|Development environment|Visual Studio Community 2015 Update 3|

The application can be downloaded from the Windows store
(\*If you are using Windows 10 / Windows 10 Mobile, the Store application opens).

[Download](https://www.microsoft.com/store/apps/9nblggh4321l)


# How to use

## Views collection

When launching the application, displays a list of IconFonts.

![home.png](https://raw.githubusercontent.com/Nia-TN1012/IconFontCollection/master/Image/en-US/home.png)

In the panel below the IconFonts list,
the icon of the selected icon font and the character code are displayed.
Press the "Copy to clipboard" button on the right side of each text box
to copy that string to the clipboard.

![icon_character_code.png](https://raw.githubusercontent.com/Nia-TN1012/IconFontCollection/master/Image/en-US/icon_character_code.png)

>**\*When using mobile device**
>
>This application is a tool for developing UWP applications,
so it is optimized for PC.
>
>Although it can be used on mobile device,
the panel in the above figure will be hidden when the width or height of the window is less than 480 epx.
(\*If you want to display it, please use "Continuum for phone" on your mobile device
and display the window of this application on the external monitor.)

|||
|---|---|
|Original Value|Displays the character code in hexadecimal (with prefix).|
|For XAML|Displays the character string converted into the format "&#xXXXX;" that can be used as it is in XAML.|
|For Code-behind|Displays the character string converted from the character code to the format "\uXXXX" that can be used as it is in the code-behind.|


```xml
<!-- A character string for XAML can be used by copying and pasting it directly to Button's Content etc. -->
<Button x:Name="ForXAML"
	FontFamily="{ThemeResource SymbolThemeFontFamily}"
	Content="&#xE001;"/>
```

```csharp
// The original value can be used as numeric type by copy & paste.
int originalValue = 0xE001;
// With the char.ConvertFromUtf32 method, the original value can be converted to a string corresponding to the icon font.
string icon = char.ConvertFromUtf32( originalValue );

// A character string for code-behind can be used as a char type literal by copy & paste.
char forCodeBehind = '\uE001';
```

## Views favorites

This application has a function to register frequently used IconFonts as favorites.

![set_favorite.png](https://raw.githubusercontent.com/Nia-TN1012/IconFontCollection/master/Image/set_favorite.png)

When you press the button of the star mark in the right-bottom corner of the item,
and then registration and cancellation the IconFont to favorites.

A list of IconFonts registered as favorites can be viewed on the Favorites page.

![favorite.png](https://raw.githubusercontent.com/Nia-TN1012/IconFontCollection/master/Image/en-US/favorite.png)

## Navigation menu

When you press the hamburger button on the left-top, opens the navigation menu.

![navigation.png](https://raw.githubusercontent.com/Nia-TN1012/IconFontCollection/master/Image/en-US/navigation.png)

|||
|---|---|
|Collection|Return to the Collection page from another page.(\*)|
|Favorites|Navigate to Favorites page.|
|User Guide|Open the user guide page ( this page ).|
|Settings|Open the application settings page.|

(\*) When pressing at the IconFont list (Collection) page,
scrolls to the first item.

## User Guide

Displays the IconFont Collection's user manual.

![userguide.png](https://raw.githubusercontent.com/Nia-TN1012/IconFontCollection/master/Image/en-US/userguide.png)

## Settings

On the setting page, you set up the application,
and displays information about the application.

![settings.png](https://raw.githubusercontent.com/Nia-TN1012/IconFontCollection/master/Image/en-US/settings.png)

|||
|---|---|
|Clear all registered favorites|Clears all registered favorite IconFonts.|
|Restore the favorites from local|Restores the favorites from local in starting application.|

# About IconFont Collection

The copyright of IconFont Collection is possessed by Chronoir.net.

    (C)2016 Chronoir.net

## Legal Disclaimer

The author and Chronoir.net accept no any responsibility for any obstacles or damages
caused by using this application.
Please be understanding of this beforehand.

# Change log

* 2016/10/23 : Released Ver. 1.1.1 (First edition).
* 2016/11/15 : Released Ver. 1.2.2
