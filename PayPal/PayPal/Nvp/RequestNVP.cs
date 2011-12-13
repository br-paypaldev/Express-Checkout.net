namespace PayPal.Nvp {
	public class RequestNVP :NVP {
		public RequestNVP () :base() {
		}
		
		public string Method {
			get { return Get( "METHOD" ); }
			set { Set( "METHOD" , value ); }
		}
		
		public string Password {
			get { return Get( "PWD" ); }
			set { Set( "PWD" , value ); }
		}
		
		public string Signature {
			get { return Get( "SIGNATURE" ); }
			set { Set( "SIGNATURE" , value ); }
		}
		
		public string Subject {
			get { return Get( "SUBJECT" ); }
			set { Set( "SUBJECT" , value ); }
		}
		
		public string Version {
			get { return Get( "VERSION" ); }
			set { Set( "VERSION" , value ); }
		}
		
		public string User {
			get { return Get( "USER" ); }
			set { Set( "USER" , value ); }
		}
	}
}