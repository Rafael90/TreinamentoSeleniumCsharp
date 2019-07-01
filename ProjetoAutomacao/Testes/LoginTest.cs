using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetoAutomacao.PageObjects;

namespace ProjetoAutomacao.Testes
{
    [TestClass]
    public class LoginTest : BaseTest
    {

        [TestMethod]
        [DataSource("System.Data.Odbc", "Dsn=Excel Files;Driver={Microsoft Excel Driver (*.xls)};dbq=|DataDirectory|\\Massa de Dados\\Login.xls;defaultdir =.;driverid=790;maxbuffersize=2048;pagetimeout=5;readonly=true", "Plan1$", DataAccessMethod.Sequential)]
        public void LoginValido()
        {
            string email = TestContext.DataRow["Email"].ToString();
            string senha = TestContext.DataRow["Senha"].ToString();

            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            //Forma Estrutural
            new HomeNaoLogadaPage(driver)
                 .AcessarLogin()
                 .PreencherEmail(email)
                 .PreencherSenha(senha);

            //funcao de print

            new LoginPage(driver).ClicarSignIn();
       

            HomeLogadaPage homeLogada = new HomeLogadaPage(driver);
            Assert.IsNotNull(homeLogada.VerificaHomeLogada());

            //Forma Funcional
            /*  Assert.IsNotNull(new HomeNaoLogadaPage(driver)
                 .AcessarPaginaLogin()
                 .Logar(email, senha)
                 .VerificaHomeLogada());*/


            //Sem utilizar o fluent page objects (é necessário criar uma nova instância a cada nova página)
            /*  new HomeNaoLogadaPage(driver)
                 .AcessarPaginaLogin();

               new LoginPage(driver)
                  .PreencherEmail()
                  .PreencherSenha()
                  .ClicarSignIn();

               Assert.IsNotNull(new HomeLogadaPage(driver)
                  .VerificaHomeLogada());*/
        }

        [TestMethod]
        public void LoginInvalido()
        {
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            //Forma Estrutural
            /*
             Assert.AreEqual("There is 1 error Authentication failed.",
             new HomeNaoLogadaPage(driver)
                 .AcessarPaginaLogin()
                 .PreencherEmail("teste@a.com")
                 .PreencherSenha("notapassword")
                 .ClicarSignInInvalido()
                 .VerificarMensagemAlertaErro());
                 */

            //Forma Funcional            
            new HomeNaoLogadaPage(driver)
                 .AcessarLogin()
                 .Logar("teste@a.com", "notapassword");

            Assert.AreEqual("There is 1 error Authentication failed.", new LoginPage(driver)
                .VerificarMensagemAlertaErro());

        }
    }
}
