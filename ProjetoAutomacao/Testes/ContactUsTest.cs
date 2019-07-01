using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoAutomacao.PageObjects;

namespace ProjetoAutomacao.Testes
{
    [TestClass]
    public class ContactUsTest : BaseTest
    {

        [TestMethod]
        public void FaleConoscoValido()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            HomeNaoLogadaPage homePage = new HomeNaoLogadaPage(driver);
            homePage.AcessarContactUs();

            ContactUsPage contactPage = new ContactUsPage(driver);

            //Forma Estruturada
            string textoRetornado =
            contactPage.PreencherComboAssunto("Customer service")
                       .PreencherEmail("teste@teste.com")
                       .PreencherNumeroPedido("12346579")
                       .EnviarArquivoDeUpload(@"C:\Dev\teste.txt")
                       .PreencherMensagem("Mensagem de Teste")
                       .ClicarEnviar()
                       .VerificarMensagemSucesso();

            //Forma Funcional
            //string textoRetornado =
            //contactPage.PreencherSolicitacao("Customer service", "teste@teste.com", "12346579", @"C:\Dev\teste.txt", "Mensagem de Teste")
            //           .VerificarMensagemSucesso();

            Assert.AreEqual("Your message has been successfully sent to our team.", textoRetornado);

        }

        [TestMethod]
        public void FaleConoscoEmailInvalido()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            HomeNaoLogadaPage homePage = new HomeNaoLogadaPage(driver);
            homePage.AcessarContactUs();

            ContactUsPage contactPage = new ContactUsPage(driver);

            //Forma Estrurada
            string textoRetornado =
            contactPage.PreencherComboAssunto("Customer service")
                       .PreencherEmail("emailinvalido")
                       .PreencherNumeroPedido("12346579")
                       .EnviarArquivoDeUpload(@"C:\Dev\teste.txt")
                       .PreencherMensagem("Mensagem de Teste")
                       .ClicarEnviar()
                       .VerificarMensagemAlertaErro();

            //Forma Funcional
            //string textoRetornado =
            //contactPage.PreencherSolicitacao("Customer service", "emailinvalido", "12346579", @"C:\Dev\teste.txt", "Mensagem de Teste")
            //           .VerificarMensagemAlertaErro();

            Assert.AreEqual("There is 1 error Invalid email address.", textoRetornado);

        }

    }
}
