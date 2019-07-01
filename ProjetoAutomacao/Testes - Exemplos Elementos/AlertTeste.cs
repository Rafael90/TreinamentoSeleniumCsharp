using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class AlertTeste : BaseTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/mudancadefoco/alert");

            driver.FindElement(By.XPath("//button[@onclick='jsAlert()']")).Click();

            //driver.SwitchTo().Alert().Accept();

            //Ler texto do Alert
            var texto = driver.SwitchTo().Alert().Text;

            driver.SwitchTo().Alert().Dismiss();
            
            Thread.Sleep(2000);
                
            driver.FindElement(By.XPath("//button[@onclick='jsConfirm()']")).Click();

            driver.SwitchTo().Alert().Accept();

            //driver.SwitchTo().Alert().Dismiss();

            Thread.Sleep(2000);
            
            //Não funciona no Chrome
            driver.FindElement(By.XPath("//button[@onclick='jsPrompt()']")).Click();

            driver.SwitchTo().Alert().SendKeys("Wheee");
            driver.SwitchTo().Alert().Accept();
            
        }
    }
}
