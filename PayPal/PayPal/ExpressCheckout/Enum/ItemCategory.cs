namespace PayPal.ExpressCheckout.Enum {
	using System;
	using System.Collections.Generic;
	using PayPal.Enum;
	
	public class ItemCategory :AbstractTypeSafeEnumeration {
		private static readonly Dictionary<string, ItemCategory> itemCategory = new Dictionary<string, ItemCategory>();
		
		private static readonly ItemCategory DIGITAL = new ItemCategory( "Digital" , 1 );
		private static readonly ItemCategory PHYSICAL = new ItemCategory( "Physical" , 2 );
		
		public ItemCategory ( string name , int value ) :base( name , value ) {
			itemCategory["Digital"] = DIGITAL;
			itemCategory["Physical"] = PHYSICAL;
		}
		
		public static explicit operator ItemCategory( string value ) {
			ItemCategory result;
			
			if (itemCategory.TryGetValue( value , out result ) ) {
				return result;
			} else {
				throw new InvalidCastException();
			}
		}
	}
}