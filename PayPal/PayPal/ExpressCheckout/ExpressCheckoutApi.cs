namespace PayPal.ExpressCheckout {
	using System;
	using System.Collections.Specialized;
	using System.Collections.Generic;
	using System.IO;
	using System.Net;
	using System.Text;
	using PayPal.Enum;
	using PayPal.Nvp;

	public class ExpressCheckoutApi {
		const String PAYPAL_HOST = "api-3t.paypal.com";
		const String PAYPAL_SANDBOX = "api-3t.sandbox.paypal.com";

		private static String version = "72.0";

		private String user;
		private String pswd;
		private String signature;
		private Boolean _sandbox = false;

		public ExpressCheckoutApi( String user , String pswd , String signature ) {
			this.user = user;
			this.pswd = pswd;
			this.signature = signature;
		}

		RequestNVP createNVP() {
			RequestNVP nvp = new RequestNVP();
			
			nvp.Version = version;
			nvp.User = user;
			nvp.Password = pswd;
			nvp.Signature = signature;

			return nvp;
		}
		
		public DoExpressCheckoutPaymentOperation DoExpressCheckoutPayment( string token , string payerid , PaymentAction action ) {
			return new DoExpressCheckoutPaymentOperation( this , token , payerid , action );
		}

		ResponseNVP execute( RequestNVP requestNvp ) {
			StringBuilder spec = new StringBuilder( "https://" );
			spec.Append( _sandbox ? PAYPAL_SANDBOX : PAYPAL_HOST );
			spec.Append( "/nvp" );

			HttpWebRequest request = (HttpWebRequest) WebRequest.Create( spec.ToString() );

			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";

			using ( Stream stream = request.GetRequestStream() ) {
				UTF8Encoding encoding = new UTF8Encoding();
				byte[] bytes = encoding.GetBytes( requestNvp.ToString() );

				stream.Write( bytes , 0 , bytes.Length );
			}

			HttpWebResponse response = (HttpWebResponse) request.GetResponse();
			ResponseNVP responseNvp;

			using ( Stream stream = response.GetResponseStream() ) {
				using ( StreamReader reader = new StreamReader( stream , Encoding.UTF8 ) ) {
					string result = reader.ReadToEnd();

					responseNvp = (ResponseNVP) result.ToString();
				}
			}

			return responseNvp;
		}

		public bool inSandbox() {
			return _sandbox;
		}

		public ExpressCheckoutApi sandbox() {
			_sandbox = true;

			return this;
		}
		
		public GetExpressCheckoutDetailsOperation GetExpressCheckoutDetails( string token ) {
			return new GetExpressCheckoutDetailsOperation( this , token );
		}

		public SetExpressCheckoutOperation SetExpressCheckout( string returnURL , String cancelURL ) {
			return new SetExpressCheckoutOperation( this , returnURL , cancelURL );
		}

		public static void setVersion( string version ) {
			ExpressCheckoutApi.version = version;
		}

		public abstract class Operation {
			private ExpressCheckoutApi ec;
			private RequestNVP requestNVP;
			private ResponseNVP responseNVP;
			private CurrencyCode currencyCode = CurrencyCode.DEFAULT;
			private LocaleCode localeCode = LocaleCode.DEFAULT;

			public Operation( ExpressCheckoutApi ec ) {
				this.ec = ec;

				requestNVP = ec.createNVP();
			}
			
			public CurrencyCode CurrencyCode {
				get { return currencyCode; }
				set {
					currencyCode = value;
					updateCurrency();
				}
			}
			
			public LocaleCode LocaleCode {
				get { return localeCode; }
				set {
					localeCode = value;
					requestNVP.Set( "LOCALECODE" , value.ToString() );
				}
			}
			
			public string Token {
				get { return RequestNVP.Get( "TOKEN" ); }
				set { requestNVP.Set( "TOKEN" , value ); }
			}
			
			public RequestNVP RequestNVP {
				get { return requestNVP; }
			}

			public ResponseNVP ResponseNVP {
				get { return responseNVP; }
			}

			public virtual Operation execute() {
				responseNVP = ec.execute( requestNVP );

				return this;
			}

			public bool inSandbox() {
				return ec.inSandbox();
			}
			
			public Operation sandbox() {
				ec.sandbox();

				return this;
			}
			
			protected virtual void updateCurrency() {}
		}
		
		public abstract class OperationWithPaymentRequest :Operation {
			private Dictionary<int,PaymentRequest> paymentRequest = new Dictionary<int, PaymentRequest>();
			
			public OperationWithPaymentRequest( ExpressCheckoutApi ec ) :base( ec ) {}
			
			public PaymentRequest PaymentRequest( int n ) {
				if ( n >= 0 && n <= 9 ) {
					PaymentRequest request;
					
					if ( !paymentRequest.TryGetValue( n , out request ) ) {
						request = new PaymentRequest( this , n );
						request.CurrencyCode = this.CurrencyCode;
						
						paymentRequest[ n ] = request;
					}
					
					return request;
				} else {
					throw new ArgumentOutOfRangeException();
				}
			}
			
			protected override void updateCurrency() {
				for ( int i = 0 , t = paymentRequest.Count ; i < t ; ++i ) {
					paymentRequest[i].CurrencyCode = this.CurrencyCode;
				}
			}
		}
	}
}