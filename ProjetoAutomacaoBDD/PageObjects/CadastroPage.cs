using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace ProjetoAutomacaoBDD.PageObjects
{
    class CadastroPage : BasePage
    {
        public CadastroPage(IWebDriver driver) : base(driver)
        {
        }

        #region Objetos

        #region YourPersonalInformation

        [FindsBy(How = How.Id, Using = "id_gender1")]
        private IWebElement radTituloMasculino { get; set; }

        [FindsBy(How = How.Id, Using = "id_gender2")]
        private IWebElement radTituloFeminino { get; set; }

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        private IWebElement txtNomePersonalInfo { get; set; }

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        private IWebElement txtSobrenomePersonalInfo { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "passwd")]
        private IWebElement txtSenha { get; set; }

        [FindsBy(How = How.Id, Using = "days")]
        private IWebElement cbbDiaNascimento { get; set; }

        [FindsBy(How = How.Id, Using = "months")]
        private IWebElement cbbMesNascimento { get; set; }

        [FindsBy(How = How.Id, Using = "years")]
        private IWebElement cbbAnoNascimento { get; set; }

        [FindsBy(How = How.Id, Using = "newsletter")]
        private IWebElement chkSignUpNewsletter { get; set; }

        [FindsBy(How = How.Id, Using = "optin")]
        private IWebElement chkReceiveSpecialOffers { get; set; }

        #endregion YourPersonalInformation

        #region YourAddress

        [FindsBy(How = How.Id, Using = "firstname")]
        private IWebElement txtNomeAddress { get; set; }

        [FindsBy(How = How.Id, Using = "lastname")]
        private IWebElement txtSobrenomeAddress { get; set; }

        [FindsBy(How = How.Id, Using = "company")]
        private IWebElement txtEmpresa { get; set; }

        [FindsBy(How = How.Id, Using = "address1")]
        private IWebElement txtEndereço { get; set; }

        [FindsBy(How = How.Id, Using = "address2")]
        private IWebElement txtComplemento { get; set; }

        [FindsBy(How = How.Id, Using = "city")]
        private IWebElement txtCidade { get; set; }

        [FindsBy(How = How.Id, Using = "id_state")]
        private IWebElement cbbEstado { get; set; }

        [FindsBy(How = How.Id, Using = "postcode")]
        private IWebElement txtCep { get; set; }

        [FindsBy(How = How.Id, Using = "id_country")]
        private IWebElement cbbPais { get; set; }

        [FindsBy(How = How.Id, Using = "other")]
        private IWebElement txtInformacoesAdicionais { get; set; }

        [FindsBy(How = How.Id, Using = "phone")]
        private IWebElement txtTelefone { get; set; }

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        private IWebElement txtCelular { get; set; }

        [FindsBy(How = How.Id, Using = "alias")]
        private IWebElement txtIdentificacaoEndereco { get; set; }

        [FindsBy(How = How.Id, Using = "submitAccount")]
        private IWebElement btnRegistrar { get; set; }

        #endregion YourAddress

        #endregion Objetos

        #region Metodos

        public CadastroPage SelecionarTitulo(string texto)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(radTituloMasculino));

            if (texto == "Mr.")
            {
                radTituloMasculino.Click();
            }
            else if (texto == "Mrs.")
            {
                radTituloFeminino.Click();
            }
            return this;
        }

        public CadastroPage PreencherNomeInformacoesPessoais(string texto)
        {
            txtNomePersonalInfo.SendKeys(texto);
            return this;
        }

        public CadastroPage PreencherSobreNomeInformacoesPessoais(string texto)
        {
            txtSobrenomePersonalInfo.SendKeys(texto);
            return this;
        }

        public CadastroPage ClicarCampoEmail()
        {
            txtEmail.Click();
            return this;
        }

        public CadastroPage PreencherCampoSenha(string texto)
        {
            txtSenha.SendKeys(texto);
            return this;
        }

        public CadastroPage SelecionarDiaNascimento(string texto)
        {
            SelectElement combo = new SelectElement(cbbDiaNascimento);
            combo.SelectByValue(texto);
            return this;
        }

        public CadastroPage SelecionarMesNascimento(string texto)
        {
            SelectElement combo = new SelectElement(cbbMesNascimento);
            combo.SelectByText(texto + " ");
            return this;
        }

        public CadastroPage SelecionarAnoNascimento(string texto)
        {
            SelectElement combo = new SelectElement(cbbAnoNascimento);
            combo.SelectByValue(texto);
            return this;
        }

        public CadastroPage SelecionarRecebimentoNewsletter()
        {
            chkSignUpNewsletter.Click();
            return this;
        }

        public CadastroPage SelecionarRecebimentoOfertasEspeciais()
        {
            chkReceiveSpecialOffers.Click();
            return this;
        }

        public CadastroPage PreencherNomeEndereço(string texto)
        {
            txtNomeAddress.SendKeys(texto);
            return this;
        }

        public CadastroPage PreencherSobreNomeEndereço(string texto)
        {
            txtSobrenomeAddress.SendKeys(texto);
            return this;
        }

        public CadastroPage PreencherEmpresa(string texto)
        {
            txtEmpresa.SendKeys(texto);
            return this;
        }

        public CadastroPage PreencherEndereco(string texto)
        {
            txtEndereço.SendKeys(texto);
            return this;
        }

        public CadastroPage PreencherComplemento(string texto)
        {
            txtComplemento.SendKeys(texto);
            return this;
        }

        public CadastroPage PreencherCidade(string texto)
        {
            txtCidade.SendKeys(texto);
            return this;
        }

        public CadastroPage SelecionarEstado()
        {
            SelectElement combo = new SelectElement(cbbEstado);
            int randomIndex = new Random().Next(1, (combo.Options.Count - 1));
            combo.SelectByIndex(randomIndex);
            return this;
        }

        public CadastroPage PreencherCep(string texto)
        {
            txtCep.SendKeys(texto);
            return this;
        }

        public CadastroPage SelecionarPais(string texto)
        {
            SelectElement combo = new SelectElement(cbbPais);
            combo.SelectByText(texto);
            return this;
        }

        public CadastroPage PreencherInformacoesAdicionais(string texto)
        {
            txtInformacoesAdicionais.SendKeys(texto);
            return this;
        }

        public CadastroPage PreencherTelefone(string texto)
        {
            txtTelefone.SendKeys(texto);
            return this;
        }

        public CadastroPage PreencherCelular(string texto)
        {
            txtCelular.SendKeys(texto);
            return this;
        }

        public CadastroPage PreencherIdentificaoEndereco(string texto)
        {
            txtIdentificacaoEndereco.Clear();
            txtIdentificacaoEndereco.SendKeys(texto);
            return this;
        }

        public CadastroPage ClicarRegistrar()
        {
            btnRegistrar.Click();
            return this;
        }

        //Criando um metodo para forma funcional
        public CadastroPage PreencherCadastroValido(string titulo, string nome, string sobreNome,
            string senha, string diaNascimento, string mesNascimento,
            string anoNascimento, string empresa, string endereco,
            string complemento, string cidade, string cep,
            string pais, string informacoesAdicionais, string telefone,
            string celular, string identificacaoEndereco)
        {
            SelecionarTitulo(titulo)
           .PreencherNomeInformacoesPessoais(nome)
           .PreencherSobreNomeInformacoesPessoais(sobreNome)
           .ClicarCampoEmail()
           .PreencherCampoSenha(senha)
           .SelecionarDiaNascimento(diaNascimento)
           .SelecionarMesNascimento(mesNascimento)
           .SelecionarAnoNascimento(anoNascimento)
           .SelecionarRecebimentoNewsletter()
           .SelecionarRecebimentoOfertasEspeciais()
           .PreencherEmpresa(empresa)
           .PreencherEndereco(endereco)
           .PreencherComplemento(complemento)
           .PreencherCidade(cidade)
           .SelecionarEstado()
           .PreencherCep(cep)
           .SelecionarPais(pais)
           .PreencherInformacoesAdicionais(informacoesAdicionais)
           .PreencherTelefone(telefone)
           .PreencherCelular(celular)
           .PreencherIdentificaoEndereco(identificacaoEndereco)
           .ClicarRegistrar();
            return this;
        }

        #endregion Metodos
    }
}

