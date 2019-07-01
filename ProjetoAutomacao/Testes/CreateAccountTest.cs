using ProjetoAutomacao.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Bogus;
using Bogus.DataSets;

namespace ProjetoAutomacao.Testes
{
    [TestClass]
    public class CreateAccountTest : BaseTest
    {
        [TestMethod]
        public void CadastroValido()
        {
            //Criando os dados necessários para o teste            
            Faker gerador = new Faker("en_US");
            Name.Gender genero;
            genero = gerador.Person.Gender;
            string titulo;
            if (genero.ToString() == "Male")
            {
                titulo = "Mr.";
            }
            else
            {
                titulo = "Mrs.";
            }
            string nome = gerador.Name.FirstName(genero);
            string sobreNome = gerador.Name.LastName(genero);
            string email = gerador.Internet.Email(nome, sobreNome);
            string senha = "1234qwer";
            DateTime dataNascimento = gerador.Date.Past(70, DateTime.Now.AddYears(-18));
            string diaNascimento = dataNascimento.Day.ToString();
            string mesNascimento = new CultureInfo("en-US").DateTimeFormat.GetMonthName(dataNascimento.Month);
            string anoNascimento = dataNascimento.Year.ToString();
            string empresa = gerador.Company.CompanyName();
            string endereco = gerador.Address.StreetAddress();
            string complemento = gerador.Address.SecondaryAddress();
            string cidade = gerador.Address.City();
            string cep = gerador.Address.ZipCode("#####");
            string pais = "United States";
            string informacoesAdicionais = gerador.Lorem.Paragraph(1);
            string telefone = gerador.Phone.PhoneNumber("(###) ###-####");
            string celular = gerador.Phone.PhoneNumber("(###) #####-####");
            string identificacaoEndereco = gerador.Address.StreetSuffix();

            //Navega ate a url
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");

            HomeNaoLogadaPage homenaoLogadaPage = new HomeNaoLogadaPage(driver);
            homenaoLogadaPage.AcessarLogin();

            LoginPage loginPage = new LoginPage(driver);
            loginPage.PreencherNovoEmail(email)
                     .ClicarCriarConta();

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

            //Forma Funcional
            //cadastroPage.PreencherCadastroValido(titulo, nome, sobreNome, senha, diaNascimento,
            //    mesNascimento, anoNascimento, empresa, endereco,
            //    complemento, cidade, cep, pais,
            //    informacoesAdicionais, telefone, celular, identificacaoEndereco);

            HomeLogadaPage homeLogada = new HomeLogadaPage(driver);
            Assert.IsNotNull(homeLogada.VerificaHomeLogada());
        }


    }
}
