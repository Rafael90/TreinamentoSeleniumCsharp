using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class AutenticacaoTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/basicauth/home");

            //Não funciona no Chrome            
            //IAlert alert = driver.SwitchTo().Alert();
            //alert.SendKeys("admin" + Keys.Tab + "admin");
            //alert.Accept();
           
            //Alternativa quando o usuário e senha são passados diretamente pela url:
            //formato da url: https://username:password@www.example.com
            driver.Navigate().GoToUrl("https://admin:admin@automacaocombatista.herokuapp.com/basicauth/home");
          
        }
    }
}
