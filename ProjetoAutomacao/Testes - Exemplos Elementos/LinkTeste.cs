using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class LinkTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/buscaelementos/links");

            //driver.FindElement(By.LinkText("Ok 200 - Sucess")).Click();

            //driver.FindElement(By.PartialLinkText("Erro 400")).Click();

            //driver.FindElement(By.TagName("a")).Click();

            driver.FindElement(By.XPath("//a[@href='/buscaelementos/notfound']")).Click();

        }
    }
}
