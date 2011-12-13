namespace PayPal.ExpressCheckout {
	using System;
	using System.Text;
	using PayPal.Enum;
	using PayPal.ExpressCheckout.Enum;

	public class SetExpressCheckoutOperation : ExpressCheckoutApi.OperationWithPaymentRequest {
		public SetExpressCheckoutOperation( ExpressCheckoutApi ec , string returnURL , string cancelURL ) :base( ec ) {
			RequestNVP.Method = "SetExpressCheckout";
			ReturnURL = returnURL;
			CancelURL = cancelURL;
		}

		public bool AddressOverride {
			get { return RequestNVP.GetBool( "ADDROVERRIDE" ); }
			set { RequestNVP.Set( "ADDROVERRIDE" , value ? "1" : "0" ); }		}

		public bool AllowNote {
			get { return RequestNVP.GetBool( "ALLOWNOTE" ); }
			set { RequestNVP.Set( "ALLOWNOTE" , value ? "1" : "0" ); }
		}

		public string BankPendingUrl {
			get { return RequestNVP.Get( "BANKTXNPENDINGURL" ); }
			set { RequestNVP.Set( "BANKTXNPENDINGURL" , value ); }
		}

		public string BrandName {
			get { return RequestNVP.Get( "BRANDNAME" ); }
			set { RequestNVP.Set( "BRANDNAME" , value ); }
		}

		public bool BuyerEmailOptinEnable {
			get { return RequestNVP.GetBool( "BUYEREMAILOPTINENABLE" ); }
			set { RequestNVP.Set( "BUYEREMAILOPTINENABLE" , value ? "1" : "0" ); }
		}

		public string Callback {
			get { return RequestNVP.Get( "CALLBACK" ); }
			set { RequestNVP.Set( "CALLBACK" , value ); }
		}

		public int CallbackTimeout {
			get { return RequestNVP.GetInt( "CALLBACKTIMEOUT" ); }
			set {
				if ( value >= 1 && value <= 6 ) {
					RequestNVP.Set( "CALLBACKTIMEOUT" , value );
				} else {
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public string CallbackVersion {
			get { return RequestNVP.Get( "CALLBACKVERSION" ); }
			set { RequestNVP.Set( "CALLBACKVERSION" , value ); }
		}

		public string CancelURL {
			get { return RequestNVP.Get( "CANCELURL" ); }
			set { RequestNVP.Set( "CANCELURL" , value ); }
		}

		public ChannelType ChannelType {
			get {
				string value = RequestNVP.Get( "CHANNELTYPE" );
				return value == null ? null : (ChannelType) value;
			}
			set { RequestNVP.Set( "CHANNELTYPE" , value.ToString() ); }
		}

		public string CustomerServiceNumber {
			get { return RequestNVP.Get( "CUSTOMERSERVICENUMBER" ); }
			set {
				if ( value.Length <= 16 ) {
					RequestNVP.Set( "CUSTOMERSERVICENUMBER" , value );
				} else {
					throw new ArgumentOutOfRangeException();
				}
			}
		}

		public string Email {
			get { return RequestNVP.Get( "EMAIL" ); }
			set { RequestNVP.Set( "EMAIL" , value ); }
		}

		public bool GiftMessageEnable {
			get { return RequestNVP.GetBool( "GIFTMESSAGEENABLE" ); }
			set { RequestNVP.Set( "GIFTMESSAGEENABLE" , value ? "1" : "0" ); }
		}

		public bool GiftReceiptEnable {
			get { return RequestNVP.GetBool( "GIFTRECEIPTENABLE" ); }
			set { RequestNVP.Set( "GIFTRECEIPTENABLE" , value ? "1" : "0" ); }
		}

		public double GiftWrapAmount {
			get { return RequestNVP.GetDouble( "GIFTWRAPAMOUNT" ); }
			set { RequestNVP.Set( "GIFTWRAPAMOUNT" , value ); }
		}

		public bool GiftWrapEnable {
			get { return RequestNVP.GetBool( "GIFTWRAPENABLE" ); }
			set { RequestNVP.Set( "GIFTWRAPENABLE" , value ? "1" : "0" ); }
		}

		public string GiftWrapName {
			get { return RequestNVP.Get( "GIFTWRAPNAME" ); }
			set { RequestNVP.Set( "GIFTWRAPNAME" , value ); }
		}

		public string GiropayCancelUrl {
			get { return RequestNVP.Get( "GIROPAYCANCELURL" ); }
			set { RequestNVP.Set( "GIROPAYCANCELURL" , value ); }
		}

		public string GiropaySuccessUrl {
			get { return RequestNVP.Get( "GIROPAYSUCCESSURL" ); }
			set { RequestNVP.Set( "GIROPAYSUCCESSURL" , value ); }
		}

		public string HeaderBackgroundColor {
			get { return RequestNVP.Get( "HDRBACKCOLOR" ); }
			set { RequestNVP.Set( "HDRBACKCOLOR" , value ); }
		}

		public string HeaderBorderColor {
			get { return RequestNVP.Get( "HDRBORDERCOLOR" ); }
			set { RequestNVP.Set( "HDRBORDERCOLOR" , value ); }
		}

		public string HeaderImage {
			get { return RequestNVP.Get( "HDRIMG" ); }
			set { RequestNVP.Set( "HDRIMG" , value ); }
		}

		public LandingPage LandingPage {
			get { return (LandingPage) RequestNVP.Get( "LANDINGPAGE" ); }
			set { RequestNVP.Set( "LANDINGPAGE" , value.ToString() ); }
		}

		public bool NoShipping {
			get { return RequestNVP.GetBool( "NOSHIPPING" ); }
			set { RequestNVP.Set( "NOSHIPPING" , value ? "1" : "0" ); }
		}

		public double MaxAmount {
			get { return RequestNVP.GetDouble( "MAXAMT" ); }
			set { RequestNVP.Set( "MAXAMT" , value ); }
		}

		public string PageStyle {
			get { return RequestNVP.Get( "PAGESTYLE" ); }
			set { RequestNVP.Set( "PAGESTYLE" , value ); }
		}

		public string PayFlowColor {
			get { return RequestNVP.Get( "PAYFLOWCOLOR" ); }
			set { RequestNVP.Set( "PAYFLOWCOLOR" , value ); }
		}

		public string RedirectUrl {
			get {
				if ( ResponseNVP != null ) {
					StringBuilder spec = new StringBuilder( "https://www." );
					spec.Append( inSandbox() ? "sandbox.paypal.com" : "paypal.com" );
					spec.Append( "/cgi-bin/webscr?cmd=_express-checkout&token=" );
					spec.Append( ResponseNVP.Get( "TOKEN" ) );

					return spec.ToString();
				}

				return null;
			}
		}

		public bool RequireConfirmedAddress {
			get { return RequestNVP.GetBool( "REQCONFIRMSHIPPING" ); }
			set { RequestNVP.Set( "REQCONFIRMSHIPPING" , value ? "1" : "0" ); }
		}

		public bool RequireConfirmShipping {
			get { return RequestNVP.GetBool( "REQCONFIRMSHIPPING" ); }
			set { RequestNVP.Set( "REQCONFIRMSHIPPING" , value ? "1" : "0" ); }
		}

		public string ReturnURL {
			get { return RequestNVP.Get( "RETURNURL" ); }
			set { RequestNVP.Set( "RETURNURL" , value ); }
		}

		public bool ShippingAddressOverride {
			get { return RequestNVP.GetBool( "ADDROVERRIDE" ); }
			set { RequestNVP.Set( "ADDROVERRIDE" , value ? "1" : "0" ); }
		}

		public SolutionType SolutionType {
			get {
				string value = RequestNVP.Get( "SOLUTIONTYPE" );

				return value == null ? null : (SolutionType) value;
			}
			set { RequestNVP.Set( "SOLUTIONTYPE" , value.ToString() ); }
		}

		public string[] SurveyChoice {
			get {
				string choice;
				string[] choices = new string[]{};
				int index = 0;

				while ( ( choice = RequestNVP.Get( "L_SURVEYCHOICE" + index ) ) != null ) {
					choices.SetValue( choice , index );
					++index;
				}

				return choices;
			}
			set {
				for ( int i = 0 , t = value.Length ; i < t ; ++i ) {
					RequestNVP.Set( "L_SURVEYCHOICE" + i , value[ i ] );
				}
			}
		}

		public bool SurveyEnable {
			get { return RequestNVP.GetBool( "SURVEYENABLE" ); }
			set { RequestNVP.Set( "SURVEYENABLE" , value ? "1" : "0" ); }
		}

		public string SurveyQuestion {
			get { return RequestNVP.Get( "SURVEYQUESTION" ); }
			set { RequestNVP.Set( "SURVEYQUESTION" , value ); }
		}
	}
}