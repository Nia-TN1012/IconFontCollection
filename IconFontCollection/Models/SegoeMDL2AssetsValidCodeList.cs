#region Version info.
/**
*	@file SegoeMDL2AssetsValidCodeList.cs
*	@brief Represents a range of character code.
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

/// <summary>
///		<see cref="IconFontCollection"/> namespace
/// </summary>
namespace IconFontCollection {

	/// <summary>
	///		Represents a range of character code.
	/// </summary>
	public class CharacterCodeRange {
		/// <summary>
		///		Gets and sets the beginning of the character code.
		/// </summary>
		public int Start { get; set; }
		/// <summary>
		///		Gets and sets the endning of the character code.
		/// </summary>
		public int End { get; set; }
	}

	/// <summary>
	///		Represents a list of available character code in the "Segoe MDL2 Assets" font.
	/// </summary>
	public class SegoeMDL2AssetsValidCodeList {

		/// <summary>
		///		Gets the list of available character code in the "Segoe MDL2 Assets" font.
		/// </summary>
		public static CharacterCodeRange[] CharacterCodesList { get; } = new CharacterCodeRange[] {
			// U+000～U+0FF
			new CharacterCodeRange { Start = 0xE001, End = 0xE00C },
			new CharacterCodeRange { Start = 0xE00E, End = 0xE019 },
			new CharacterCodeRange { Start = 0xE052, End = 0xE052 },
			new CharacterCodeRange { Start = 0xE07F, End = 0xE07F },
			new CharacterCodeRange { Start = 0xE081, End = 0xE082 },
			new CharacterCodeRange { Start = 0xE08F, End = 0xE08F },
			new CharacterCodeRange { Start = 0xE094, End = 0xE094 },
			new CharacterCodeRange { Start = 0xE096, End = 0xE0A2 },
			new CharacterCodeRange { Start = 0xE0A5, End = 0xE0A6 },
			new CharacterCodeRange { Start = 0xE0AB, End = 0xE0AB },
			new CharacterCodeRange { Start = 0xE0AD, End = 0xE0AE },
			new CharacterCodeRange { Start = 0xE0B4, End = 0xE0B5 },
			new CharacterCodeRange { Start = 0xE0C4, End = 0xE0C4 },
			new CharacterCodeRange { Start = 0xE0D5, End = 0xE0D5 },
			new CharacterCodeRange { Start = 0xE0E2, End = 0xE0E5 },
			new CharacterCodeRange { Start = 0xE0E7, End = 0xE0E7 },

			// U+100～U+1FF
			new CharacterCodeRange { Start = 0xE100, End = 0xE156 },
			new CharacterCodeRange { Start = 0xE158, End = 0xE17D },
			new CharacterCodeRange { Start = 0xE181, End = 0xE1A8 },
			new CharacterCodeRange { Start = 0xE1AA, End = 0xE1C0 },
			new CharacterCodeRange { Start = 0xE1C2, End = 0xE1EA },
			new CharacterCodeRange { Start = 0xE1EC, End = 0xE1EF },
			new CharacterCodeRange { Start = 0xE1F1, End = 0xE1F7 },
			new CharacterCodeRange { Start = 0xE1FD, End = 0xE1FD },

			// U+200～U+2FF
			new CharacterCodeRange { Start = 0xE206, End = 0xE206 },
			new CharacterCodeRange { Start = 0xE208, End = 0xE20B },
			new CharacterCodeRange { Start = 0xE211, End = 0xE212 },
			new CharacterCodeRange { Start = 0xE224, End = 0xE224 },
			new CharacterCodeRange { Start = 0xE228, End = 0xE228 },
			new CharacterCodeRange { Start = 0xE248, End = 0xE24A },
			new CharacterCodeRange { Start = 0xE25A, End = 0xE25E },
			new CharacterCodeRange { Start = 0xE26B, End = 0xE26C },
			new CharacterCodeRange { Start = 0xE28F, End = 0xE292 },
			new CharacterCodeRange { Start = 0xE294, End = 0xE295 },
			new CharacterCodeRange { Start = 0xE297, End = 0xE299 },
			new CharacterCodeRange { Start = 0xE29B, End = 0xE29B },
			new CharacterCodeRange { Start = 0xE2AC, End = 0xE2B4 },
			new CharacterCodeRange { Start = 0xE2F6, End = 0xE2F7 },

			// U+700～U+7FF
			new CharacterCodeRange { Start = 0xE700, End = 0xE72E },
			new CharacterCodeRange { Start = 0xE730, End = 0xE730 },
			new CharacterCodeRange { Start = 0xE734, End = 0xE735 },
			new CharacterCodeRange { Start = 0xE738, End = 0xE756 },
			new CharacterCodeRange { Start = 0xE759, End = 0xE769 },
			new CharacterCodeRange { Start = 0xE76B, End = 0xE77C },
			new CharacterCodeRange { Start = 0xE77F, End = 0xE781 },
			new CharacterCodeRange { Start = 0xE783, End = 0xE78C },
			new CharacterCodeRange { Start = 0xE799, End = 0xE799 },
			new CharacterCodeRange { Start = 0xE7A5, End = 0xE7A8 },
			new CharacterCodeRange { Start = 0xE7AC, End = 0xE7AD },
			new CharacterCodeRange { Start = 0xE7B5, End = 0xE7B5 },
			new CharacterCodeRange { Start = 0xE7B7, End = 0xE7B8 },
			new CharacterCodeRange { Start = 0xE7BA, End = 0xE7BA },
			new CharacterCodeRange { Start = 0xE7BC, End = 0xE7BC },
			new CharacterCodeRange { Start = 0xE7BE, End = 0xE7C1 },
			new CharacterCodeRange { Start = 0xE7C3, End = 0xE7C9 },
			new CharacterCodeRange { Start = 0xE7DE, End = 0xE7DE },
			new CharacterCodeRange { Start = 0xE7E3, End = 0xE7E3 },
			new CharacterCodeRange { Start = 0xE7E6, End = 0xE7E8 },
			new CharacterCodeRange { Start = 0xE7EA, End = 0xE7FD },

			// U+800～U+8FF
			new CharacterCodeRange { Start = 0xE802, End = 0xE806 },
			new CharacterCodeRange { Start = 0xE809, End = 0xE80A },
			new CharacterCodeRange { Start = 0xE80C, End = 0xE80D },
			new CharacterCodeRange { Start = 0xE80F, End = 0xE80F },
			new CharacterCodeRange { Start = 0xE811, End = 0xE816 },
			new CharacterCodeRange { Start = 0xE819, End = 0xE81F },
			new CharacterCodeRange { Start = 0xE821, End = 0xE823 },
			new CharacterCodeRange { Start = 0xE825, End = 0xE826 },
			new CharacterCodeRange { Start = 0xE829, End = 0xE830 },
			new CharacterCodeRange { Start = 0xE835, End = 0xE836 },
			new CharacterCodeRange { Start = 0xE839, End = 0xE89C },
			new CharacterCodeRange { Start = 0xE89E, End = 0xE8C6 },
			new CharacterCodeRange { Start = 0xE8C8, End = 0xE8FF },

			// U+900～U+9FF
			new CharacterCodeRange { Start = 0xE904, End = 0xE916 },
			new CharacterCodeRange { Start = 0xE91B, End = 0xE91C },
			new CharacterCodeRange { Start = 0xE91F, End = 0xE91F },
			new CharacterCodeRange { Start = 0xE921, End = 0xE929 },
			new CharacterCodeRange { Start = 0xE92C, End = 0xE939 },
			new CharacterCodeRange { Start = 0xE93C, End = 0xE93C },
			new CharacterCodeRange { Start = 0xE93E, End = 0xE93E },
			new CharacterCodeRange { Start = 0xE943, End = 0xE958 },
			new CharacterCodeRange { Start = 0xE95A, End = 0xE95B },
			new CharacterCodeRange { Start = 0xE95D, End = 0xE95E },
			new CharacterCodeRange { Start = 0xE960, End = 0xE96A },
			new CharacterCodeRange { Start = 0xE96D, End = 0xE98A },
			new CharacterCodeRange { Start = 0xE98F, End = 0xE990 },
			new CharacterCodeRange { Start = 0xE992, End = 0xE996 },
			new CharacterCodeRange { Start = 0xE998, End = 0xE998 },
			new CharacterCodeRange { Start = 0xE99A, End = 0xE99A },
			new CharacterCodeRange { Start = 0xE9A1, End = 0xE9A1 },
			new CharacterCodeRange { Start = 0xE9A9, End = 0xE9BC },
			new CharacterCodeRange { Start = 0xE9CA, End = 0xE9CA },
			new CharacterCodeRange { Start = 0xE9D9, End = 0xE9D9 },
			new CharacterCodeRange { Start = 0xE9F3, End = 0xE9F3 },

			// U+A00～U+AFF
			new CharacterCodeRange { Start = 0xEA14, End = 0xEA14 },
			new CharacterCodeRange { Start = 0xEA1F, End = 0xEA1F },
			new CharacterCodeRange { Start = 0xEA21, End = 0xEA21 },
			new CharacterCodeRange { Start = 0xEA24, End = 0xEA24 },
			new CharacterCodeRange { Start = 0xEA35, End = 0xEA35 },
			new CharacterCodeRange { Start = 0xEA37, End = 0xEA3B },
			new CharacterCodeRange { Start = 0xEA40, End = 0xEA44 },
			new CharacterCodeRange { Start = 0xEA47, End = 0xEA4C },
			new CharacterCodeRange { Start = 0xEA4E, End = 0xEA58 },
			new CharacterCodeRange { Start = 0xEA5B, End = 0xEA5C },
			new CharacterCodeRange { Start = 0xEA5E, End = 0xEA65 },
			new CharacterCodeRange { Start = 0xEA69, End = 0xEA6A },
			new CharacterCodeRange { Start = 0xEA6C, End = 0xEA6C },
			new CharacterCodeRange { Start = 0xEA80, End = 0xEA84 },
			new CharacterCodeRange { Start = 0xEA86, End = 0xEA86 },
			new CharacterCodeRange { Start = 0xEA89, End = 0xEA8F },
			new CharacterCodeRange { Start = 0xEA91, End = 0xEA95 },
			new CharacterCodeRange { Start = 0xEA97, End = 0xEA99 },
			new CharacterCodeRange { Start = 0xEADF, End = 0xEADF },

			// U+B00～U+BFF
			new CharacterCodeRange { Start = 0xEB05, End = 0xEB05 },
			new CharacterCodeRange { Start = 0xEB0F, End = 0xEB0F },
			new CharacterCodeRange { Start = 0xEB11, End = 0xEB11 },
			new CharacterCodeRange { Start = 0xEB42, End = 0xEB42 },
			new CharacterCodeRange { Start = 0xEB47, End = 0xEB52 },
			new CharacterCodeRange { Start = 0xEB55, End = 0xEB63 },
			new CharacterCodeRange { Start = 0xEB66, End = 0xEB68 },
			new CharacterCodeRange { Start = 0xEB7E, End = 0xEB7E },
			new CharacterCodeRange { Start = 0xEB82, End = 0xEB8D },
			new CharacterCodeRange { Start = 0xEB90, End = 0xEB91 },
			new CharacterCodeRange { Start = 0xEB95, End = 0xEB97 },
			new CharacterCodeRange { Start = 0xEB9D, End = 0xEBC0 },
			new CharacterCodeRange { Start = 0xEBC3, End = 0xEBC6 },
			new CharacterCodeRange { Start = 0xEBD2, End = 0xEBD2 },
			new CharacterCodeRange { Start = 0xEBD4, End = 0xEBD9 },
			new CharacterCodeRange { Start = 0xEBDE, End = 0xEBDE },
			new CharacterCodeRange { Start = 0xEBE6, End = 0xEBE7 },
			new CharacterCodeRange { Start = 0xEBFC, End = 0xEC00 },

			// U+C00～U+CFF
			new CharacterCodeRange { Start = 0xEC02, End = 0xEC02 },
			new CharacterCodeRange { Start = 0xEC05, End = 0xEC0B },
			new CharacterCodeRange { Start = 0xEC11, End = 0xEC16 },
			new CharacterCodeRange { Start = 0xEC19, End = 0xEC19 },
			new CharacterCodeRange { Start = 0xEC1B, End = 0xEC1B },
			new CharacterCodeRange { Start = 0xEC1E, End = 0xEC1E },
			new CharacterCodeRange { Start = 0xEC20, End = 0xEC20 },
			new CharacterCodeRange { Start = 0xEC24, End = 0xEC27 },
			new CharacterCodeRange { Start = 0xEC31, End = 0xEC31 },
			new CharacterCodeRange { Start = 0xEC37, End = 0xEC4A },
			new CharacterCodeRange { Start = 0xEC4E, End = 0xEC52 },
			new CharacterCodeRange { Start = 0xEC54, End = 0xEC5C },
			new CharacterCodeRange { Start = 0xEC61, End = 0xEC61 },
			new CharacterCodeRange { Start = 0xEC64, End = 0xEC64 },
			new CharacterCodeRange { Start = 0xEC6D, End = 0xEC6D },
			new CharacterCodeRange { Start = 0xEC71, End = 0xEC72 },
			new CharacterCodeRange { Start = 0xEC74, End = 0xEC77 },
			new CharacterCodeRange { Start = 0xEC7A, End = 0xEC7A },
			new CharacterCodeRange { Start = 0xEC7E, End = 0xEC81 },
			new CharacterCodeRange { Start = 0xEC87, End = 0xEC88 },
			new CharacterCodeRange { Start = 0xEC8A, End = 0xEC8A },
			new CharacterCodeRange { Start = 0xEC87, End = 0xEC88 },
			new CharacterCodeRange { Start = 0xEC8F, End = 0xEC8F },
			new CharacterCodeRange { Start = 0xEC92, End = 0xEC92 },
			new CharacterCodeRange { Start = 0xECA5, End = 0xECA5 },
			new CharacterCodeRange { Start = 0xECA7, End = 0xECA7 },
			new CharacterCodeRange { Start = 0xECAA, End = 0xECAA },
			new CharacterCodeRange { Start = 0xECC4, End = 0xECCD },
			new CharacterCodeRange { Start = 0xECE7, End = 0xECE9 },
			new CharacterCodeRange { Start = 0xECC4, End = 0xECCD },
			new CharacterCodeRange { Start = 0xECF0, End = 0xECF1 },
			new CharacterCodeRange { Start = 0xECF3, End = 0xECF3 },

			// U+D00～U+DFF
			new CharacterCodeRange { Start = 0xED0C, End = 0xED0D },
			new CharacterCodeRange { Start = 0xED10, End = 0xED10 },
			new CharacterCodeRange { Start = 0xED15, End = 0xED15 },
			new CharacterCodeRange { Start = 0xED1E, End = 0xED1F },
			new CharacterCodeRange { Start = 0xED28, End = 0xED28 },
			new CharacterCodeRange { Start = 0xED2A, End = 0xED33 },
			new CharacterCodeRange { Start = 0xED39, End = 0xED3A },
			new CharacterCodeRange { Start = 0xED3C, End = 0xED3D },
			new CharacterCodeRange { Start = 0xED41, End = 0xED44 },
			new CharacterCodeRange { Start = 0xED47, End = 0xED47 },
			new CharacterCodeRange { Start = 0xED28, End = 0xED28 },
			new CharacterCodeRange { Start = 0xED4C, End = 0xED4D },
			new CharacterCodeRange { Start = 0xED53, End = 0xED67 },
			new CharacterCodeRange { Start = 0xEDA2, End = 0xEDB1 },
			new CharacterCodeRange { Start = 0xEDB3, End = 0xEDB5 },
			new CharacterCodeRange { Start = 0xEDC6, End = 0xEDC6 },
			new CharacterCodeRange { Start = 0xEDE1, End = 0xEDE2 },
			new CharacterCodeRange { Start = 0xEDFB, End = 0xEDFB },

			// U+E00～U+EFF
			new CharacterCodeRange { Start = 0xEE35, End = 0xEE35 },
			new CharacterCodeRange { Start = 0xEE3F, End = 0xEE40 },
			new CharacterCodeRange { Start = 0xEE56, End = 0xEE57 },
			new CharacterCodeRange { Start = 0xEE63, End = 0xEE65 },
			new CharacterCodeRange { Start = 0xEE71, End = 0xEE71 },
			new CharacterCodeRange { Start = 0xEE77, End = 0xEE77 },
			new CharacterCodeRange { Start = 0xEE79, End = 0xEE7A },
			new CharacterCodeRange { Start = 0xEE92, End = 0xEE94 },

			// U+F00～U+FFF
			new CharacterCodeRange { Start = 0xEF15, End = 0xEF19 },
			new CharacterCodeRange { Start = 0xEF1F, End = 0xEF20 },
		};
	}
}
