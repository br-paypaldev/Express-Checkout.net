namespace PayPal.ExpressCheckout {
	using System;
	using PayPal.Enum;
	
	public class GetExpressCheckoutDetailsOperation : ExpressCheckoutApi.Operation {
		public GetExpressCheckoutDetailsOperation( ExpressCheckoutApi ec , string token ) :base( ec ) {
			RequestNVP.Method = "GetExpressCheckoutDetails";
			Token = token;
		}
	}
}