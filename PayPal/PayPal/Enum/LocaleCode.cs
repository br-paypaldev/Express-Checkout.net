namespace PayPal.Enum {
	using System;

	public sealed class LocaleCode :AbstractTypeSafeEnumeration {
		public static readonly LocaleCode AUSTRALIA = new LocaleCode( "AU" , 1 );
		public static readonly LocaleCode AUSTRIA = new LocaleCode( "AT" , 2 );
		public static readonly LocaleCode BELGIUM = new LocaleCode( "BE" , 3 );
		public static readonly LocaleCode BRAZIL = new LocaleCode( "BR" , 4 );
		public static readonly LocaleCode CANADA = new LocaleCode( "CA" , 5 );
		public static readonly LocaleCode SWITZERLAND = new LocaleCode( "CH" , 6 );
		public static readonly LocaleCode CHINA = new LocaleCode( "CN" , 7 );
		public static readonly LocaleCode GERMANY = new LocaleCode( "DE" , 8 );
		public static readonly LocaleCode SPAIN = new LocaleCode( "ES" , 9 );
		public static readonly LocaleCode UNITED_KINGDOM = new LocaleCode( "GB" , 10 );
		public static readonly LocaleCode FRANCE = new LocaleCode( "FR" , 11 );
		public static readonly LocaleCode ITALY = new LocaleCode( "IT" , 12 );
		public static readonly LocaleCode NETHERLANDS = new LocaleCode( "NL" , 13 );
		public static readonly LocaleCode POLAND = new LocaleCode( "PL" , 14 );
		public static readonly LocaleCode PORTUGAL = new LocaleCode( "PT" , 15 );
		public static readonly LocaleCode RUSSIA = new LocaleCode( "RU" , 16 );
		public static readonly LocaleCode UNITED_STATES = new LocaleCode( "US" , 17 );
		public static readonly LocaleCode DANISH = new LocaleCode( "da_DK" , 18 );
		public static readonly LocaleCode HEBREW = new LocaleCode( "he_IL" , 19 );
		public static readonly LocaleCode INDONESIAN = new LocaleCode( "id_ID" , 20 );
		public static readonly LocaleCode JAPANESE = new LocaleCode( "jp_JP" , 21 );
		public static readonly LocaleCode NORWEGIAN = new LocaleCode( "no_NO" , 22 );
		public static readonly LocaleCode BRAZILIAN_PORTUGUESE = new LocaleCode( "pt_BR" , 23 );
		public static readonly LocaleCode RUSSIAN = new LocaleCode( "ru_RU" , 24 );
		public static readonly LocaleCode SWEEDISH = new LocaleCode( "sv_SE" , 25 );
		public static readonly LocaleCode THAI = new LocaleCode( "th_TH" , 26 );
		public static readonly LocaleCode TURKISH = new LocaleCode( "tr_TR" , 27 );
		public static readonly LocaleCode SIMPLIFIED_CHINESE = new LocaleCode( "zh_CN" , 28 );
		public static readonly LocaleCode HONG_KONG_TRADITIONAL_CHINESE = new LocaleCode( "zh_HK" , 29 );
		public static readonly LocaleCode TAIWAN_TRADITIONAL_CHINESE = new LocaleCode( "zh_TW" , 30 );
		public static readonly LocaleCode DEFAULT = LocaleCode.UNITED_STATES;
		
		private LocaleCode ( string name , int value ) :base( name , value ) {}
	}
}