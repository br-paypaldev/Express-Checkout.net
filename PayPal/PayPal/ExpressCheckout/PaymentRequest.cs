namespace PayPal.ExpressCheckout {
	using System;
	using PayPal.Enum;
	using PayPal.ExpressCheckout.Enum;

	public class PaymentRequest {
		private ExpressCheckoutApi.Operation o;
		private PaymentAction action;
		private int n;
		private int m;
		private double itemAmount = 0;
		private double amount = 0;
		private double taxAmount = 0;
		private double shippingAmount = 0;
		private double handlingAmount = 0;
		private double insuranceAmount = 0;
		private double shippingDiscountAmount = 0;

		public PaymentRequest ( ExpressCheckoutApi.Operation o , int n ) {
			this.o = o;
			this.n = n;
			this.m = 0;

			Action = PaymentAction.SALE;
		}

		public PaymentAction Action {
			get { return action; }
			set {
				action = value;
				o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_PAYMENTACTION" , value.ToString() );
			}
		}

		public double Amount {
			get { return amount; }
			set {
				amount = value;
				o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_AMT" , value );
			}
		}

		public CurrencyCode CurrencyCode {
			get {
				string value = o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_CURRENCYCODE" );

				return value == null ? CurrencyCode.US_DOLLAR : (CurrencyCode) value;
			}
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_CURRENCYCODE" , value.ToString() ); }
		}
		
		public string Custom {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_CUSTOM" ); }
			set {
				if ( value.Length <= 256 ) {
					o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_CUSTOM" , value );
				} else {
					throw new ArgumentOutOfRangeException();
				}
			}
		}
		
		public string Description {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_DESC" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_DESC" , value ); }
		}

		public string Email {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_EMAIL" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_EMAIL" , value ); }
		}

		public double HandlingAmount {
			get { return handlingAmount; }
			set {
				Amount += value - handlingAmount;
				handlingAmount = value;
				o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_HANDLINGAMT" , value );
			}
		}

		public double InsuranceAmount {
			get { return insuranceAmount; }
			set {
				Amount += value - insuranceAmount;
				insuranceAmount = value;
				o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_INSURANCEAMT" , value );
			}
		}
		
		public bool InsuranceOptionOffered {
			get { return o.RequestNVP.GetBool( "PAYMENTREQUEST_" + n + "_INSURANCEOPTIONOFFERED" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_INSURANCEOPTIONOFFERED" , value ); }
		}	
		
		public string InvoiceNum {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_INVNUM" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_INVNUM" , value ); }
		}

		public double ItemAmount {
			get { return itemAmount; }
			set {
				Amount += value - itemAmount;
				itemAmount = value;
				o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_ITEMAMT" , value );
			}
		}
		
		public string NoteText {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_NOTETEXT" ); }
			set {
				if ( value.Length <= 255 ) {
					o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_NOTETEXT" , value );
				} else {
					throw new ArgumentOutOfRangeException();
				}
			}
		}
		
		public string NotifyUrl {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_NOTIFYURL" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_NOTIFYURL" , value ); }
		}
		
		public string PaymentRequestId {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_PAYMENTREQUESTID" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_PAYMENTREQUESTID" , value ); }
		}
			

		public double ShippingAmount {
			get { return shippingAmount; }
			set {
				Amount += value - shippingAmount;
				shippingAmount = value;
				o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPPINGAMT" , value );
			}
		}

		public double ShippingDiscountAmount {
			get { return shippingDiscountAmount; }
			set {
				Amount += value - shippingDiscountAmount;
				shippingDiscountAmount = value;
				o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPDISCAMT" , value );
			}
		}

		public string ShipToCity {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_SHIPTOCITY" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPTOCITY" , value ); }
		}

		public string ShipToCountryCode {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_SHIPTOCOUNTRYCODE" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPTOCOUNTRYCODE" , value ); }
		}

		public string ShipToPhoneNum {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_SHIPTOPHONENUM" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPTOPHONENUM" , value ); }
		}

		public string ShipToName {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_SHIPTONAME" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPTONAME" , value ); }
		}

		public string ShipToState {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_SHIPTOSTATE" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPTOSTATE" , value ); }
		}

		public string ShipToStreet {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_SHIPTOSTREET" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPTOSTREET" , value ); }
		}

		public string ShipToStreet2 {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_SHIPTOSTREET2" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPTOSTREET2" , value ); }
		}

		public string ShipToZip {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_SHIPTOZIP" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_SHIPTOZIP" , value ); }
		}

		public double TaxAmount {
			get { return o.RequestNVP.GetDouble( "PAYMENTREQUEST_" + n + "_TAXAMT" ); }
			set {
				Amount += value - taxAmount;
				taxAmount = value;
				o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_TAXAMT" , value );
			}
		}
		
		public string TransactionId {
			get { return o.RequestNVP.Get( "PAYMENTREQUEST_" + n + "_TRANSACTIONID" ); }
			set { o.RequestNVP.Set( "PAYMENTREQUEST_" + n + "_TRANSACTIONID" , value ); }
		}

		public Item addItem( string name , int quantity , double amount ) {
			Item item = new Item( this , n , m );
			
			item.Name = name;
			item.Amount = amount;
			item.Quantity = quantity;
			
			m++;
			
			return item;
		}

		public Item addItem( string name , int quantity , double amount , string description ) {
			Item item = addItem( name , quantity , amount );
			item.Description = description;
			
			return item;
		}
		
		ExpressCheckoutApi.Operation operation() {
			return o;
		}
		
		void updateItemAmount( Item item , double oldAmount ) {
			ItemAmount += (item.Amount*item.Quantity) - oldAmount;
		}
		
		public class Item {
			private int m;
			private int n;
			private int qty = 0;
			private PaymentRequest r;
			private double amount;
			
			public Item( PaymentRequest r , int n , int m ) {
				this.m = m;
				this.n = n;			
				this.r = r;
			}
			
			public double Amount {
				get { return amount; }
				set {
					double old = amount;
					
					amount = value;
					r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_AMT" + m , value );
					r.updateItemAmount( this , old * qty );
				}
			}
			
			public ItemCategory Category {
				get { return (ItemCategory) r.o.RequestNVP.Get( "L_PAYMENTREQUEST_" + n + "_ITEMCATEGORY" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_ITEMCATEGORY" + m , value.ToString() ); }
			}
			
			public string Description {
				get { return r.o.RequestNVP.Get( "L_PAYMENTREQUEST_" + n + "_DESC" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_DESC" + m , value ); }
			}
			
			public double Length {
				get { return r.o.RequestNVP.GetDouble( "L_PAYMENTREQUEST_" + n + "_ITEMLENGTHVALUE" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_ITEMLENGTHVALUE" + m , value ); }
			}
			
			public string LengthUnit {
				get { return r.o.RequestNVP.Get( "L_PAYMENTREQUEST_" + n + "_ITEMLENGTHUNIT" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_ITEMLENGTHUNIT" + m , value ); }
			}
			
			public string Number {
				get { return r.o.RequestNVP.Get( "L_PAYMENTREQUEST_" + n + "_NUMBER" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_NUMBER" + m , value ); }
			}
			
			public string Name {
				get { return r.o.RequestNVP.Get( "L_PAYMENTREQUEST_" + n + "_NAME" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_NAME" + m , value ); }
			}
			
			public int Quantity {
				get { return qty; }
				set {
					int old = qty;
					qty = value;
					
					r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_QTY" + m , value );
					r.updateItemAmount( this , amount * old );
				}
			}
			
			public double TaxAmount {
				get { return r.o.RequestNVP.GetDouble( "L_PAYMENTREQUEST_" + n + "_TAXAMT" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_TAXAMT" + m , value ); }
			}
			
			public string Url {
				get { return r.o.RequestNVP.Get( "L_PAYMENTREQUEST_" + n + "_ITEMURL" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_ITEMURL" + m , value ); }
			}
			
			public double Weight {
				get { return r.o.RequestNVP.GetDouble( "L_PAYMENTREQUEST_" + n + "_ITEMWEIGHTVALUE" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_ITEMWEIGHTVALUE" + m , value ); }
			}
			
			public string WeightUnit {
				get { return r.o.RequestNVP.Get( "L_PAYMENTREQUEST_" + n + "_ITEMWEIGHTUNIT" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_ITEMWEIGHTUNIT" + m , value ); }
			}
			
			public double Width {
				get { return r.o.RequestNVP.GetDouble( "L_PAYMENTREQUEST_" + n + "_ITEMWIDTHVALUE" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_ITEMWIDTHVALUE" + m , value ); }
			}
			
			public string WidthtUnit {
				get { return r.o.RequestNVP.Get( "L_PAYMENTREQUEST_" + n + "_ITEMWIDTHUNIT" + m ); }
				set { r.o.RequestNVP.Set( "L_PAYMENTREQUEST_" + n + "_ITEMWIDTHUNIT" + m , value ); }
			}
			
		}
	}
}