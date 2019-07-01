using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class ModalTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            //Não funciona, o elemento sempre existirá no html mesmo não estando visível na tela :) 
            //Faça o teste descomentando esta linha abaixo
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/mudancadefoco/modal");

            driver.FindElement(By.CssSelector(".waves-light.btn.modal-trigger")).Click();

            //Talvez seja necessário aumentar este tempo em sua máquina
            //Comente este tempo e execute o teste N vezes
            //Repare que em algumas o texto será não exibido no output
            //Temos que descomentar esse trecho que faz com que aguarde X segundos,
            //dando tempo do texto ser exibido e lido abaixo
            //Thread.Sleep(2000);   

            //Com o uso da espera explícita
            //Aguardará que o elemento fique visível antes de prosseguir
            //Comente a linha de espera implícita antes de usar esta
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".modal-content")));
            
            //Lê o texto da modal
            var texto = driver.FindElement(By.CssSelector(".modal-content")).Text;

            //É necessário aguardar para que o texto fique visivel
            //Caso contrário a mensagem não será impressa aqui
            //O teste não quebra porque estes elementos estão sempre no html, porém ocultos
            //Mas para que o texto seja de fato lido, é necessário que ele seja de fato exibido na tela do navegador
            Console.WriteLine(texto);

            driver.Quit();
            
        }
    }
}
