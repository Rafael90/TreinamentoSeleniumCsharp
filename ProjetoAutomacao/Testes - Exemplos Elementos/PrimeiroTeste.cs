using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class PrimeiroTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Criando a instância do Chromedriver e atribuindo para a variável do tipo IWebDriver
            IWebDriver driver = new ChromeDriver();
            //IWebDriver driver = new InternetExplorerDriver();

            //Navegando para a Url desejada
            driver.Navigate().GoToUrl("https://www.google.com.br");

            //Armazenando o título da aba atual
            string titulo = driver.Title;

            //Verificando o texto
            Assert.IsTrue(titulo == "Google", "Teste falhou, resultado exibido: " + titulo);

            //Fechando os navegadores em aberto pelo driver
            driver.Quit();
        }
    }
}
