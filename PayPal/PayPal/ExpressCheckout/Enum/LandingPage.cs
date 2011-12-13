namespace PayPal.ExpressCheckout.Enum {
	using System;
	using System.Collections.Generic;
	using PayPal.Enum;
	
	public class LandingPage :AbstractTypeSafeEnumeration {
		private static readonly Dictionary<string, LandingPage> landingPage = new Dictionary<string, LandingPage>();
		
		private static readonly LandingPage BILLING = new LandingPage( "Billing" , 1 );
		private static readonly LandingPage LOGIN = new LandingPage( "Login" , 2 );
		
		public LandingPage ( string name , int value ) :base( name , value ) {
			landingPage["Billing"] = BILLING;
			landingPage["Login"] = LOGIN;
		}
		
		public static explicit operator LandingPage( string value ) {
			LandingPage result;
			
			if ( landingPage.TryGetValue( value , out result ) ) {
				return result;
			} else {
				throw new InvalidCastException();
			}
		}
	}
}