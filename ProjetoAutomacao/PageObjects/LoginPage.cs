using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace ProjetoAutomacao.PageObjects
{
    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement txtSenha { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        private IWebElement btnSignIn { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-danger")]
        private IWebElement msgAlertaErro { get; set; }

        [FindsBy(How = How.Id, Using = "email_create")]
        private IWebElement txtNovoEmail { get; set; }

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        private IWebElement btnCreateAccount { get; set; }

        //Estruturado
        public LoginPage PreencherEmail(string email)
        {
            txtEmail.SendKeys(email);
            return this;
        }

        public LoginPage PreencherSenha(string senha)
        {
            txtSenha.SendKeys(senha);
            return this;
        }

        public HomeLogadaPage ClicarSignIn()
        {
            btnSignIn.Click();
            return new HomeLogadaPage(driver);
        }

        public LoginPage ClicarSignInInvalido()
        {
            btnSignIn.Click();
            return this;
        }

        public string VerificarMensagemAlertaErro()
        {
            return msgAlertaErro.Text.Replace("\r\n", " ");
        }

        public LoginPage PreencherNovoEmail(string email)
        {
            txtNovoEmail.SendKeys(email);
            return this;
        }

        public LoginPage ClicarCriarConta()
        {
            btnCreateAccount.Click();
            return this;
        }

        //Funcional
        public HomeLogadaPage Logar(string email, string senha)
        {
            txtEmail.SendKeys(email);
            txtSenha.SendKeys(senha);
            btnSignIn.Click();
            return new HomeLogadaPage(driver);
        }

        //Funcional
        public LoginPage LogarInvalido(string email, string senha)
        {
            txtEmail.SendKeys(email);
            txtSenha.SendKeys(senha);
            btnSignIn.Click();
            return this;
        }

        //Funcional+Estruturado
        public HomeLogadaPage LogarFuncional(string email, string senha)
        {
            PreencherEmail(email);
            PreencherSenha(senha);
            ClicarSignIn();
            return new HomeLogadaPage(driver);
        }
    }
}
