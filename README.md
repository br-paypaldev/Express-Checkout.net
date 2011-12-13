Exemplo de uso
==============

Operação SetExpressCheckout
---------------------------

	SetExpressCheckoutOperation SetExpressCheckout = PayPalApiFactory.instance.ExpressCheckout(
		"usuario.da.api",
		"senha",
		"assinatura"
	).SetExpressCheckout( "http://dominio.com/url/de/sucesso" , "http://dominio.com/url/de/cancelamento" );

	SetExpressCheckout.LocaleCode = LocaleCode.BRAZILIAN_PORTUGUESE;
	SetExpressCheckout.CurrencyCode = CurrencyCode.BRAZILIAN_REAL;

	SetExpressCheckout.PaymentRequest(0).addItem( "Produto de Teste 1" , 1 , 10 , "Descrição do item" );
	SetExpressCheckout.PaymentRequest(0).TaxAmount = 3; //imposto
	SetExpressCheckout.PaymentRequest(0).ShippingAmount = 10; //custo do frete
	SetExpressCheckout.PaymentRequest(0).HandlingAmount = 3; //custo de manuseio
	SetExpressCheckout.PaymentRequest(0).ShippingDiscountAmount = -2; //desconto de frete
	SetExpressCheckout.sandbox().execute(); //Executa a operação no Sandbox

> Após a execução da operação, a URL de redirecionamento poderá ser recuperada com:

	SetExpressCheckout.RedirectUrl;

> Se estiver utilizando C# com MVC:

	namespace Controllers {
		using System;
		using System.Web.Mvc;
		using PayPal;
		using PayPal.ExpressCheckout;
		using PayPal.Enum;
	
		[HandleError]
		public class HomeController : Controller {
			public ActionResult PayWithPaypal() {
				SetExpressCheckoutOperation SetExpressCheckout = PayPalApiFactory.instance.ExpressCheckout(
					"usuario_da_api",
					"senha",
					"assinatura"
				).SetExpressCheckout( "http://dominio.com/url/de/sucesso" , "http://dominio.com/url/de/cancelamento" );
	
				SetExpressCheckout.LocaleCode = LocaleCode.BRAZILIAN_PORTUGUESE;
				SetExpressCheckout.CurrencyCode = CurrencyCode.BRAZILIAN_REAL;
	
				SetExpressCheckout.PaymentRequest(0).addItem( "Produto de Teste 1" , 1 , 10 , "Descrição do item" );
				SetExpressCheckout.PaymentRequest(0).TaxAmount = 3; //imposto
				SetExpressCheckout.PaymentRequest(0).ShippingAmount = 10; //custo do frete
				SetExpressCheckout.PaymentRequest(0).HandlingAmount = 3; //custo de manuseio
				SetExpressCheckout.PaymentRequest(0).ShippingDiscountAmount = -2; //desconto de frete
				SetExpressCheckout.sandbox().execute();
	
				return Redirect( SetExpressCheckout.RedirectUrl );
			}
		}
	}
