using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace ProjetoAutomacao.PageObjects
{
    public class ContactUsPage : BasePage
    {
        public ContactUsPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "id_contact")]
        private IWebElement cbbAssunto { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "id_order")]
        private IWebElement txtNumeroPedido { get; set; }

        [FindsBy(How = How.Id, Using = "fileUpload")]
        private IWebElement btnEnviarArquivo { get; set; }

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement txtMensagem { get; set; }

        [FindsBy(How = How.Id, Using = "submitMessage")]
        private IWebElement btnEnviarMensagem { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-success")]
        private IWebElement msgEnviadoComSucesso { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".alert.alert-danger")]
        private IWebElement msgAlertaErro { get; set; }

        public ContactUsPage PreencherComboAssunto(string texto)
        {
            SelectElement Selec_Event = new SelectElement(cbbAssunto);
            Selec_Event.SelectByText("Customer service");
            return this;
        }

        public ContactUsPage PreencherEmail(string texto)
        {
            txtEmail.SendKeys(texto);
            return this;
        }

        public ContactUsPage PreencherNumeroPedido(string texto)
        {
            txtNumeroPedido.SendKeys(texto);
            return this;
        }

        public ContactUsPage EnviarArquivoDeUpload(string caminho)
        {
            btnEnviarArquivo.SendKeys(caminho);
            return this;
        }

        public ContactUsPage PreencherMensagem(string texto)
        {
            txtMensagem.SendKeys(texto);
            return this;
        }

        public ContactUsPage ClicarEnviar()
        {
            btnEnviarMensagem.Click();
            return this;
        }

        public ContactUsPage PreencherSolicitacao(string assunto, string email, string numPedido, string caminhoArquivo, string mensagem)
        {
            PreencherComboAssunto(assunto);
            PreencherEmail(email);
            PreencherNumeroPedido(numPedido);
            EnviarArquivoDeUpload(caminhoArquivo);
            PreencherMensagem(mensagem);
            ClicarEnviar();
            return this;
        }

        public string VerificarMensagemSucesso()
        {
            return msgEnviadoComSucesso.Text;
        }

        public string VerificarMensagemAlertaErro()
        {
            return msgAlertaErro.Text.Replace("\r\n", " ");
        }

    }


}

