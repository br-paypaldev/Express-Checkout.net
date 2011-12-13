namespace PayPal.Nvp {
	using System;
	using System.Collections.Specialized;
	using System.Globalization;
	using System.Text;
	using System.Web;
	
	/// <remarks>
	/// A API NVP provê uma associação parametrizada entre os campos da requisição e
	/// da resposta, onde cada campo representa um par nome=valor.
	/// A requisição é enviada pela sua aplicação e a resposta enviada pelos servidores
	/// do PayPal utilizando um modelo servidor-cliente, onde sua aplicação é cliente
	/// do servidor do PayPal.
	/// </remarks>
	public class NVP :NameValueCollection {
		public NVP () :base() {}
		
		public bool GetBool( int index ) {
			return GetBool( GetKey( index ) );
		}
		
		public bool GetBool( string name ) {
			string value = Get( name );
			
			return value != null && ( value.Equals( "1" ) || value.Equals( "true" ) );
		}
		
		public double GetDouble( int index ) {
			return GetDouble( GetKey( index ) );
		}
		
		public double GetDouble( string name ) {
			string value = Get( name );
			
			return value == null ? 0 : double.Parse( value , CultureInfo.InvariantCulture );
		}
		
		public int GetInt( int index ) {
			return GetInt( GetKey( index ) );
		}
		
		public int GetInt( string name ) {
			string  value = Get( name );
			
			return value == null ? 0 : int.Parse( value );
		}
		
		/// <summary>
		/// Faz a conversão explícita de uma string retornada pelo PayPal em uma coleção
		/// NVP. Esse método é utilizado basicamente na conversão da resposta do servidor
		/// do PayPal em uma coleção NVP reutilizável pela aplicação.
		/// </summary>
		/// <param name="queryString">
		/// 	A <see cref="System.String"/> de resposta do PayPal que será convertida em uma coleção
		/// 	<see cref="NVP"/>.
		/// </param>
		/// <returns>
		/// 	A coleção <see cref="NVP"/> que foi convertida de uma coleção <see cref="NameValueCollection"/>
		/// </returns>
		public static explicit operator NVP( string queryString ) {
			NameValueCollection nvc = HttpUtility.ParseQueryString( queryString );
			NVP nvp = new NVP();
			
			for ( int i = 0 , t = nvc.Count ; i < t ; ++i ) {
				nvp.Set( nvc.GetKey( i ) , nvc[ i ] );
			}
			
			return nvp;
		}
		
		public void Set( string name , bool value ) {
			Set( name , value ? "true" : "false" );
		}
		
		public void Set( string name , double value ) {
			Set( name , value.ToString( CultureInfo.InvariantCulture ) );
		}
		
		public void Set( string name , int value ) {
			Set( name , value.ToString() );
		}
		
		/// <summary>
		/// Converte a coleção <see cref="NVP"/> em sua representação como <see cref="string"/>.
		/// Esse método é utilizado basicamente pela aplicação, para converter a coleção em uma
		/// query string para ser enviada para os servidores do PayPal.
		/// </summary>
		/// <returns>
		/// 	A <see cref="System.String"/> que representa essa coleção NVP e que poderá ser
		/// 	enviada para os servidores do PayPal.
		/// </returns>
		public override string ToString () {
			StringBuilder sb = new StringBuilder();
			
			Console.WriteLine( "---------------<ToString>------------------" );
			
			for ( int i = 0 , t = this.Count ; i < t ; ++i ) {
				if ( i != 0 ) {
					sb.Append( "&" );
				}
				
				Console.WriteLine( GetKey( i ) + " = " + this[ i ] );
				
				sb.Append( GetKey( i ) );
				sb.Append( "=" );
				sb.Append( HttpUtility.UrlEncode( this[ i ] ) );
			}
			
			Console.WriteLine( sb.ToString() );
			
			Console.WriteLine( "---------------</ToString>------------------" );
			
			return sb.ToString();
		}
	}
}