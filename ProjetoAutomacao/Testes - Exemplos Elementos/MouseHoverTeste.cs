using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;
using OpenQA.Selenium.Interactions;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class MouseHoverTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/iteracoes/mousehover");

            //Elemento sobre o qual o mouse deve ficar em cima
            var elemento = driver.FindElement(By.ClassName("activator"));

            //Realizar ação de mover o mouse para cima do elemento especificado
            Actions action = new Actions(driver);
            action.MoveToElement(elemento).Perform();

            //Aguardar para o texto ser exibido
            // Não é o ideal, mas apenas para fins de aprendizado neste momento usaremos o Thread.Sleep
            Thread.Sleep(2000);

            //Imprimimos o texo exibido após a ação do mouse
            Console.Write( driver.FindElement(By.ClassName("card-reveal")).Text );
        }
    }
}
