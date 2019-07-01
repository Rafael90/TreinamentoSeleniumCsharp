using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{ 
    [TestClass]
    public class TextFieldTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            //IWebDriver driver = new InternetExplorerDriver();
            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/buscaelementos/inputsetextfield");

            driver.FindElement(By.Id("first_name")).SendKeys("Teste");
        }
    }
}
