using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ProjetoAutomacaoBDD.Helpers;
using ProjetoAutomacaoBDD.PageObjects;
using TechTalk.SpecFlow;

namespace ProjetoAutomacaoBDD
{
    [Binding]
    public class FaleConoscoSteps
    {
        private IWebDriver driver;
        private TestContext test;
        string textoRetornado;

        public FaleConoscoSteps(IWebDriver driver, TestContext test)
        {
            this.driver = driver;
            this.test = test;
        }

        [When(@"acessar a página Contact Us")]
        public void QuandoAcessarAPaginaContactUs()
        {
            HomeNaoLogadaPage homePage = new HomeNaoLogadaPage(driver);
            homePage.AcessarContactUs();
        }

        [When(@"realizar o envio de uma mensagem válida")]
        public void QuandoRealizarOEnvioDeUmaMensagemValida()
        {

            ContactUsPage contactPage = new ContactUsPage(driver);
            contactPage.PreencherComboAssunto("Customer service")
                       .PreencherEmail("teste@teste.com")
                       .PreencherNumeroPedido("12346579")
                       .PreencherMensagem("Mensagem de Teste");

            test.AddResultFile(ScreenshotHelper.TiraPrint("Campos preenchidos", driver));

            textoRetornado = contactPage.ClicarEnviar()
                .VerificarMensagemSucesso();
        }

        [When(@"realizar o envio de uma mensagem informando um email inválido")]
        public void QuandoRealizarOEnvioDeUmaMensagemInformandoUmEmailInvalido()
        {
            ContactUsPage contactPage = new ContactUsPage(driver);

            contactPage.PreencherComboAssunto("Customer service")
                       .PreencherEmail("emailinvalido")
                       .PreencherNumeroPedido("12346579")
                       .PreencherMensagem("Mensagem de Teste");

            test.AddResultFile(ScreenshotHelper.TiraPrint("Campos preenchidos", driver));

            textoRetornado = contactPage.ClicarEnviar()
                       .VerificarMensagemAlertaErro();
        }

        [Then(@"devo visualizar a mensagem de sucesso")]
        public void EntaoDevoVisualizarAMensagemDeSucesso(string mensagemEsperada)
        {
            Assert.AreEqual(mensagemEsperada, textoRetornado);
        }

        [Then(@"devo visualizar a mensagem de email inválido")]
        public void EntaoDevoVisualizarAMensagemDeEmailInvalido(string mensagemEsperada)
        {
            Assert.AreEqual(mensagemEsperada, textoRetornado);
        }

    }
}
