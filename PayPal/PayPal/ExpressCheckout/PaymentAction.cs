namespace PayPal.ExpressCheckout {
	using System;
	using PayPal.Enum;

	public sealed class PaymentAction :AbstractTypeSafeEnumeration {
		public static readonly PaymentAction SALE = new PaymentAction( "Sale" , 1 );
		public static readonly PaymentAction AUTHORIZATION = new PaymentAction( "Authorization" , 2 );
		public static readonly PaymentAction ORDER = new PaymentAction( "Order" , 3 );
		
		private PaymentAction( string name , int value ) :base( name , value ) {}
	}
}