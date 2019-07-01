using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class UploadTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/outros/uploaddearquivos");

            //Mapear o campo geralmente do tipo input que corresponda ao upload
            //Passar o caminho com extensão do arquivo a ser enviado
            driver.FindElement(By.Id("upload")).SendKeys(@"C:\Users\rafael.camargo\Pictures\teste.png");

        }
    }
}
