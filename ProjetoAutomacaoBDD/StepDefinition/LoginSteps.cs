using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ProjetoAutomacaoBDD.PageObjects;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ProjetoAutomacaoBDD
{
    [Binding]
    public class LoginSteps
    {
        IWebDriver driver;
        TestContext testContext;

        public LoginSteps(IWebDriver driver, TestContext test)
        {
            this.driver = driver;
            this.testContext = test;
        }

        [Given(@"que acessei o site de compras")]
        public void DadoQueAcesseiOSiteDeCompras()
        {
             driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }
        
        [When(@"realizar um login utilizando um usuário válido")]
        public void QuandoRealizarUmLoginUtilizandoUmUsuarioValido(Table table)
        {
            dynamic user = table.CreateDynamicInstance();

            string usuario = user.Usuario;
            string senha = user.Senha;

            HomeNaoLogadaPage home = new HomeNaoLogadaPage(driver);
            home.AcessarLogin()
                .Logar(usuario, senha, testContext);
        }

        [When(@"realizar um login utilizando um email inválido")]
        public void QuandoRealizarUmLoginUtilizandoUmEmailInvalido(Table table)
        {
            dynamic user = table.CreateDynamicInstance();

            string usuario = user.Usuario;
            string senha = user.Senha;

            HomeNaoLogadaPage home = new HomeNaoLogadaPage(driver);
            home.AcessarLogin()
                .Logar(usuario, senha, testContext);
        }

        [Then(@"devo visualizar a área logada do site")]
        public void EntaoDevoVisualizarAAreaLogadaDoSite()
        {
            HomeLogadaPage home = new HomeLogadaPage(driver);
            Assert.IsNotNull(home.VerificaHomeLogada());
        }

        [Then(@"devo visualizar o alerta sobre email inválido")]
        public void EntaoDevoVisualizarOAlertaSobreEmailInvalido(String message)
        {
            Assert.AreEqual(message, new LoginPage(driver)
                .VerificarMensagemAlertaErro());
        }

        [When(@"realizar um login utilizando um email vazio")]
        public void QuandoRealizarUmLoginUtilizandoUmEmailVazio(Table table)
        {
            dynamic user = table.CreateDynamicInstance();

            string usuario = user.Usuario;
            string senha = user.Senha;

            HomeNaoLogadaPage home = new HomeNaoLogadaPage(driver);
            home.AcessarLogin()
                .Logar(usuario, senha, testContext);
        }

        [Then(@"devo visualizar o alerta sobre email vazio")]
        public void EntaoDevoVisualizarOAlertaSobreEmailVazio(string message)
        {
            Assert.AreEqual(message, new LoginPage(driver)
           .VerificarMensagemAlertaErro());
        }

        [When(@"realizar um login utilizando uma senha inválida")]
        public void QuandoRealizarUmLoginUtilizandoUmaSenhaInvalida(Table table)
        {
            dynamic user = table.CreateDynamicInstance();

            string usuario = user.Usuario;
            string senha = user.Senha;

            HomeNaoLogadaPage home = new HomeNaoLogadaPage(driver);
            home.AcessarLogin()
                .Logar(usuario, senha, testContext);
        }

        [Then(@"devo visualizar o alerta sobre uma senha inválida")]
        public void EntaoDevoVisualizarOAlertaSobreUmaSenhaInvalida(string message)
        {
            Assert.AreEqual(message, new LoginPage(driver)
           .VerificarMensagemAlertaErro());
        }

        [When(@"realizar um login utilizando uma senha vazia")]
        public void QuandoRealizarUmLoginUtilizandoUmaSenhaVazia(Table table)
        {
            dynamic user = table.CreateDynamicInstance();

            string usuario = user.Usuario;
            string senha = user.Senha;

            HomeNaoLogadaPage home = new HomeNaoLogadaPage(driver);
            home.AcessarLogin()
                .Logar(usuario, senha, testContext);
        }

        [Then(@"devo visualizar o alerta sobre uma senha vazia")]
        public void EntaoDevoVisualizarOAlertaSobreUmaSenhaVazia(string message)
        {
            Assert.AreEqual(message, new LoginPage(driver)
           .VerificarMensagemAlertaErro());
        }

        [When(@"realizar um login com usuário ""(.*)"" e senha ""(.*)""")]
        public void QuandoRealizarUmLoginComUsuarioESenha(string usuario, string senha)
        {
            HomeNaoLogadaPage home = new HomeNaoLogadaPage(driver);
            home.AcessarLogin()
                .Logar(usuario, senha, testContext);
        }

        [Then(@"devo visualizar o alerta com a mensagem ""(.*)""")]
        public void EntaoDevoVisualizarOAlertaComAMensagem(string message)
        {
            Assert.AreEqual(message, new LoginPage(driver)
         .VerificarMensagemAlertaErro());
        }


    }
}
