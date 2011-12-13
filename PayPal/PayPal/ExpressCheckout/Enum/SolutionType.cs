namespace PayPal.ExpressCheckout.Enum {
	using System;
	using System.Collections.Generic;
	using PayPal.Enum;
	
	public class SolutionType :AbstractTypeSafeEnumeration {
		private static readonly Dictionary<string, SolutionType> solution = new Dictionary<string, SolutionType>();
		
		private static readonly SolutionType SOLE = new SolutionType( "Sole" , 1 );
		private static readonly SolutionType MARK = new SolutionType( "Mark" , 2 );
		
		public SolutionType ( string name , int value ) :base( name , value ) {
			solution["Sole"] = SOLE;
			solution["Mark"] = MARK;
		}
		
		public static explicit operator SolutionType( string value ) {
			SolutionType result;
			
			if ( solution.TryGetValue( value , out result ) ) {
				return result;
			} else {
				throw new InvalidCastException();
			}
		}
	}
}