using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class BotoesTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/buscaelementos/botoes");

            //Selecionando Botão pelo ID
            driver.FindElement(By.Id("teste")).Click();

            //Selecionando botão pela Classe (Apenas um identificador)
            //driver.FindElement(By.ClassName("btn-floating")).Click();

            //Selecionando botão pelo Css (vários identificadores inciados por "." e sem espaços entre si)
            driver.FindElement(By.CssSelector(".waves-light.btn-floating")).Click();

            driver.FindElement(By.CssSelector(".btn-large.disabled"));
        }
    }
}
