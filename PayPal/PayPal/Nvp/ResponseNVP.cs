namespace PayPal.Nvp {
	using System;
	using System.Collections.Generic;
	using PayPal.Enum;
	
	/// <remarks>
	/// Representação comum para as respostas NVP do PayPal.
	/// </remarks>
	public class ResponseNVP :NVP {
		private Dictionary<int,Error> errors = new Dictionary<int, Error>();
		
		private ResponseNVP () :base() {}
		
		public Ack Ack {
			get { return (Ack) Get( "ACK" ); }
		}
		
		public string CorrelationId {
			get { return Get( "CORRELATIONID" ); }
		}
		
		public DateTime Timestamp {
			get { return DateTime.Parse( Get( "TIMESTAMP" ) ); }
		}
		
		public string Version {
			get { return Get( "VERSION" ); }
		}
		
		public string Build {
			get { return Get( "BUILD" ); }
		}
		
		public bool hasError() {
			return errors.Count > 0;
		}
		
		public Error getError( int i ) {
			return errors[i];
		}
		
		public static explicit operator ResponseNVP( string queryString ) {
			NVP nvp = (NVP) queryString;
			ResponseNVP rNvp = new ResponseNVP();
			
			for ( int i = 0 , t = nvp.Count ; i < t ; ++i ) {
				string name = nvp.GetKey( i );
				
				if ( name.Contains( "L_ERRORCODE" ) ) {
					string suffix = name.Substring( 11 , 1 );
					Error error = new Error();
					
					error.Code = nvp[ "L_ERRORCODE" + suffix ];
					error.LongMessage = nvp[ "L_LONGMESSAGE" + suffix ];
					error.ShortMessage = nvp[ "L_SHORTMESSAGE" + suffix ];
					error.SeverityCode = nvp[ "L_SEVERITYCODE" + suffix ];
					
					rNvp.errors.Add( int.Parse( suffix ) , error );
				}
				
				rNvp.Set( name , nvp[ name ] );
			}
			
			return rNvp;
		}
		
		/// <remarks>
		/// Representação de um erro que possa ter ocorrido em uma requisição.
		/// </remarks>
		public class Error {
			private string code;
			private string shortMessage;
			private string longMessage;
			private string severityCode;
			
			public Error() {}
			
			public string Code {
				get { return code; }
				set { code = value; }
			}
			
			public string ShortMessage {
				get { return shortMessage; }
				set { shortMessage = value; }
			}
			
			public string LongMessage {
				get { return longMessage; }
				set { longMessage = value; }
			}
			
			public string SeverityCode {
				get { return severityCode; }
				set { severityCode = value; }
			}
		}
	}
}