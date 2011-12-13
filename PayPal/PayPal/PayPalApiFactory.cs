namespace PayPal {
	using System;
	using System.Net;
	using System.Net.Security;
	using System.Security.Cryptography.X509Certificates;
	using PayPal.ExpressCheckout;
	
	/// <remarks>
	/// Interface para criação dos objetos de integração com as APIs do PayPal.
	/// </remarks>
	public class PayPalApiFactory {
		private static PayPalApiFactory paypalInstance;
		
		private PayPalApiFactory() {
			ServicePointManager.ServerCertificateValidationCallback = Validator;
		}
		
		/// <summary>
		/// Instância de PayPal para integração com as várias APIs do PayPal.
		/// </summary>
		public static PayPalApiFactory instance {
			get {
				if ( paypalInstance == null ) {
					paypalInstance = new PayPalApiFactory();
				}
				
				return paypalInstance;
			}
		}	
		
		/// <param name="user">
		/// 	<see cref="String"/> O nome de usuário da API
		/// </param>
		/// <param name="pwd">
		/// 	<see cref="String"/> A senha da API
		/// </param>
		/// <param name="signature">
		/// 	<see cref="String"/> Assinatura da API
		/// </param>
		/// <returns>
		/// 	Uma instância de <see cref="ExpressCheckoutApi"/> para integração com a API
		/// 	do ExpressCheckout.
		/// </returns>
		public ExpressCheckoutApi ExpressCheckout( String user , String pwd , String signature ) {
			return new ExpressCheckoutApi( user , pwd , signature );
		}
		
		bool Validator(
			object sender,
			X509Certificate certificate,
			X509Chain chain,
			SslPolicyErrors sslPolicyErrors ) {
			return true;
		}
	}
}