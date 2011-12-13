namespace PayPal.Enum {
	using System;
	using System.Collections.Generic;

	public sealed class CurrencyCode :AbstractTypeSafeEnumeration {
		private static readonly Dictionary<string, CurrencyCode> currencyCodes = new Dictionary<string, CurrencyCode>();
		public static readonly CurrencyCode AUSTRALIAN_DOLLAR = new CurrencyCode( "AUD" , 1 );
		public static readonly CurrencyCode BRAZILIAN_REAL = new CurrencyCode( "BRL" , 2 );
		public static readonly CurrencyCode CANADIAN_DOLLAR = new CurrencyCode( "CAD" , 3 );
		public static readonly CurrencyCode CZECH_KORUNA = new CurrencyCode( "CZK" , 4 );
		public static readonly CurrencyCode DANISH_KRONE = new CurrencyCode( "DKK" , 5 );
		public static readonly CurrencyCode EURO = new CurrencyCode( "EUR" , 6 );
		public static readonly CurrencyCode HONG_KONG_DOLLAR = new CurrencyCode( "HKD" , 7 );
		public static readonly CurrencyCode HUNGARIAN_FORINT = new CurrencyCode( "HUF" , 8 );
		public static readonly CurrencyCode ISRAELI_NEW_SHEQEL = new CurrencyCode( "ILS" , 9 );
		public static readonly CurrencyCode JAPAN_YEN = new CurrencyCode( "JPY" , 10 );
		public static readonly CurrencyCode MALAYSIAN_RINGGIT = new CurrencyCode( "MYR" , 11 );
		public static readonly CurrencyCode MEXICAN_PESO = new CurrencyCode( "MXN" , 12 );
		public static readonly CurrencyCode NORWEGIAN_KRONE = new CurrencyCode( "NOK" , 13 );
		public static readonly CurrencyCode NEW_ZEALAND_DOLLAR = new CurrencyCode( "NZD" , 14 );
		public static readonly CurrencyCode PHILIPPINE_PESO = new CurrencyCode( "PHP" , 15 );
		public static readonly CurrencyCode POLISH_ZLOTY = new CurrencyCode( "PLN" , 16 );
		public static readonly CurrencyCode POUND_STERLING = new CurrencyCode( "GBP" , 17 );
		public static readonly CurrencyCode SINGAPORE_DOLLAR = new CurrencyCode( "SGD" , 19 );
		public static readonly CurrencyCode SWEDISH_KRONA = new CurrencyCode( "SEK" , 20 );
		public static readonly CurrencyCode SWISS_FRANC = new CurrencyCode( "CHF" , 21 );
		public static readonly CurrencyCode TAIWAN_NEW_DOLLAR = new CurrencyCode( "TWD" , 22 );
		public static readonly CurrencyCode TAI_BAHT = new CurrencyCode( "THB" , 23 );
		public static readonly CurrencyCode TURKISH_LIRA = new CurrencyCode( "TRY" , 24 );
		public static readonly CurrencyCode US_DOLLAR = new CurrencyCode( "USD" , 25 );
		public static readonly CurrencyCode DEFAULT = CurrencyCode.US_DOLLAR;
		
		private CurrencyCode ( string name , int value ) :base( name , value ) {
			currencyCodes["AUD"] = AUSTRALIAN_DOLLAR;
			currencyCodes["BRL"] = BRAZILIAN_REAL;
			currencyCodes["CAD"] = CANADIAN_DOLLAR;
			currencyCodes["CZK"] = CZECH_KORUNA;
			currencyCodes["DKK"] = DANISH_KRONE;
			currencyCodes["EUR"] = EURO;
			currencyCodes["HKD"] = HONG_KONG_DOLLAR;
			currencyCodes["USD"] = US_DOLLAR;
		}
		
		public static explicit operator CurrencyCode( string code ) {
			CurrencyCode currencyCode;
			
			if ( currencyCodes.TryGetValue( code , out currencyCode ) ) {
				return currencyCode;
			} else {
				throw new InvalidCastException();
			}
		}
	}
}