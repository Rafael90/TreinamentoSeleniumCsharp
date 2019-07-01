using Bogus;
using Bogus.DataSets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ProjetoAutomacaoBDD.Helpers;
using ProjetoAutomacaoBDD.PageObjects;
using System;
using System.Globalization;
using TechTalk.SpecFlow;

namespace ProjetoAutomacaoBDD
{
    [Binding]
    public class CadastroSteps
    {
        private IWebDriver driver;
        private TestContext test;
        string email;
        string titulo;
        string nome;
        string sobreNome;
        string senha;
        DateTime dataNascimento;
        string diaNascimento;
        string mesNascimento;
        string anoNascimento;
        string empresa;
        string endereco;
        string complemento;
        string cidade;
        string cep;
        string pais;
        string informacoesAdicionais;
        string telefone;
        string celular;
        string identificacaoEndereco;


        public CadastroSteps(IWebDriver driver, TestContext test)
        {
            this.driver = driver;
            this.test = test;
        }

        [Given(@"que possuo um usuário não cadastrado no site")]
        public void DadoQuePossuoUmUsuarioNaoCadastradoNoSite()
        {
            //Criando os dados necessários para o teste            
            Faker gerador = new Faker("en_US");
            Name.Gender genero;
            genero = gerador.Person.Gender;
            if (genero.ToString() == "Male")
            {
                titulo = "Mr.";
            }
            else
            {
                titulo = "Mrs.";
            }
            nome = gerador.Name.FirstName(genero);
            sobreNome = gerador.Name.LastName(genero);
            email = gerador.Internet.Email(nome, sobreNome);
            senha = "1234qwer";
            dataNascimento = gerador.Date.Past(70, DateTime.Now.AddYears(-18));
            diaNascimento = dataNascimento.Day.ToString();
            mesNascimento = new CultureInfo("en-US").DateTimeFormat.GetMonthName(dataNascimento.Month);
            anoNascimento = dataNascimento.Year.ToString();
            empresa = gerador.Company.CompanyName();
            endereco = gerador.Address.StreetAddress();
            complemento = gerador.Address.SecondaryAddress();
            cidade = gerador.Address.City();
            cep = gerador.Address.ZipCode("#####");
            pais = "United States";
            informacoesAdicionais = gerador.Lorem.Paragraph(1);
            telefone = gerador.Phone.PhoneNumber("(###) ###-####");
            celular = gerador.Phone.PhoneNumber("(###) #####-####");
            identificacaoEndereco = gerador.Address.StreetSuffix();
        }

        [When(@"acessar a página de login")]
        public void QuandoAcessarAPaginaDeLogin()
        {
            HomeNaoLogadaPage homenaoLogadaPage = new HomeNaoLogadaPage(driver);
            homenaoLogadaPage.AcessarLogin();
        }

        [When(@"informar o email do novo usuário")]
        public void QuandoInformarOEmailDoNovoUsuario()
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.PreencherNovoEmail(email)
                     .ClicarCriarConta();
        }

        [When(@"realizar seu cadastro")]
        public void QuandoRealizarSeuCadastro()
        {
            //Forma Estrutural
            CadastroPage cadastroPage = new CadastroPage(driver);
            cadastroPage.SelecionarTitulo(titulo)
                .PreencherNomeInformacoesPessoais(nome)
                .PreencherSobreNomeInformacoesPessoais(sobreNome)
                .ClicarCampoEmail()
                .PreencherCampoSenha(senha)
                .SelecionarDiaNascimento(diaNascimento)
                .SelecionarMesNascimento(mesNascimento)
                .SelecionarAnoNascimento(anoNascimento)
                .SelecionarRecebimentoNewsletter()
                .SelecionarRecebimentoOfertasEspeciais();

            test.AddResultFile(ScreenshotHelper.TiraPrint("Dados Pessoais preechidos", driver));

            cadastroPage.PreencherEmpresa(empresa)
                .PreencherEndereco(endereco)
                .PreencherComplemento(complemento)
                .PreencherCidade(cidade)
                .SelecionarEstado();

            test.AddResultFile(ScreenshotHelper.TiraPrint("Dados Endereço parte um preechidos", driver));

            cadastroPage.PreencherCep(cep)
                .SelecionarPais(pais)
                .PreencherInformacoesAdicionais(informacoesAdicionais)
                .PreencherTelefone(telefone)
                .PreencherCelular(celular)
                .PreencherIdentificaoEndereco(identificacaoEndereco);

            test.AddResultFile(ScreenshotHelper.TiraPrint("Dados Endereço parte dois preechidos", driver));

            cadastroPage.ClicarRegistrar();
        }
    }
}
