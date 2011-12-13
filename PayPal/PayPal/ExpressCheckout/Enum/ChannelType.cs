namespace PayPal.ExpressCheckout.Enum {
	using System;
	using System.Collections.Generic;
	using PayPal.Enum;
	
	public class ChannelType :AbstractTypeSafeEnumeration {
		private static readonly Dictionary<string, ChannelType> channelType = new Dictionary<string, ChannelType>();
		
		private static readonly ChannelType MERCHANT = new ChannelType( "Merchant" , 1 );
		private static readonly ChannelType EBAYITEM = new ChannelType( "eBayItem" , 2 );
		
		public ChannelType ( string name , int value ) :base( name , value ) {
			channelType["Merchant"] = MERCHANT;
			channelType["eBayItem"] = EBAYITEM;
		}
		
		public static explicit operator ChannelType( string value ) {
			ChannelType result;
			
			if ( channelType.TryGetValue( value , out result ) ) {
				return result;
			} else {
				throw new InvalidCastException();
			}
		}
	}
}