using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class DropDownTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/buscaelementos/dropdowneselect");

            var combo = driver.FindElement(By.ClassName("browser-default"));
            SelectElement select = new SelectElement(combo);
            //select.SelectByValue("3");
            select.SelectByText("Internet Explorer");

        }
    }
}
