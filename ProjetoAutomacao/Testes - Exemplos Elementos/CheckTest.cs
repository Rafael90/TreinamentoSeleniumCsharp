using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class CheckTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://developer.mozilla.org/en-US/docs/Web/HTML/Element/input/checkbox");

            bool selecionadoSubscribe;

            //Mudar foco para o frame em qual o elemento se encontra
            driver.SwitchTo().Frame(driver.FindElement(By.Id("frame_Value")));
            
            //Realiza o scroll até o elemento
            var element = driver.FindElement(By.Id("subscribeNews"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();

            //Verifica se esta selecionado
            selecionadoSubscribe = driver.FindElement(By.Id("subscribeNews")).Selected;
            Console.WriteLine("Selecionado : " + selecionadoSubscribe);

            //Clica no elemento
            driver.FindElement(By.Id("subscribeNews")).Click();
            Console.WriteLine("Click no Checkbox");

            //Verifica se esta selecionado
            selecionadoSubscribe = driver.FindElement(By.Id("subscribeNews")).Selected;
            Console.WriteLine("Selecionado : " + selecionadoSubscribe);

            //Retorna o foco para a página principal
            driver.SwitchTo().DefaultContent();
        }
    }
}
