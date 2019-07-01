using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class NovaAbaTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/mudancadefoco/janela");

            Console.WriteLine("Abas Abertas: " + driver.WindowHandles.Count);
            Console.WriteLine("Url da janela atual: " + driver.Url);

            //Clico no botão para abrir uma nova aba
            driver.FindElement(By.CssSelector(".btn.waves-light.red")).Click();
            Console.WriteLine("Abas Abertas: " + driver.WindowHandles.Count);

            //Armazena o "ID" da ultima janela através do WindowHandle
            string newWindowHandle = driver.WindowHandles.Last();
            var newWindow = driver.SwitchTo().Window(newWindowHandle);

            Console.WriteLine("Url da janela atual: " + driver.Url);

        }
    }
}
