using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ProjetoAutomacaoBDD.Helpers;
using ProjetoAutomacaoBDD.PageObjects;
using System;
using System.Data;
using System.IO;
using TechTalk.SpecFlow;

namespace ProjetoAutomacaoBDD
{
    [Binding]
    public class LoginExcelSteps
    {
        private IWebDriver driver;
        private TestContext test;
        LoginFieldsHelper loginFields;

        public LoginExcelSteps(IWebDriver driver, TestContext test)
        {
            this.driver = driver;
            this.test = test;
        }

        [Given(@"que possuo um usuário ""(.*)""")]
        public void DadoQuePossuoUmUsuario(string tipo)
        {
            string caminhoAssembly = System.IO.Directory.GetCurrentDirectory();
            caminhoAssembly = new Uri(caminhoAssembly).LocalPath;
            string novoCaminho = Path.GetFullPath(Path.Combine(caminhoAssembly, @"../../"));
            string caminhoPlanilha = novoCaminho + "MassaDeDados\\" + "Login.xlsx";

            string query = "SELECT * FROM [Plan1$] where [Tipo] = '" + tipo + "'";

            DataSet ds = ExcelReaderHelper.QueryFromSheet(caminhoPlanilha, query);

            loginFields = new LoginFieldsHelper();
            loginFields.usuario = ds.Tables[0].Rows[0]["Usuario"].ToString();
            loginFields.senha = ds.Tables[0].Rows[0]["Senha"].ToString();
        }


        [When(@"realizar um login com os dados que foram lidos")]
        public void QuandoRealizarUmLoginComOsDadosQueForamLidos()
        {
            ;

            HomeNaoLogadaPage home = new HomeNaoLogadaPage(driver);
            home.AcessarLogin()
                .Logar(loginFields.usuario, loginFields.senha, test);
        }


    }
}
