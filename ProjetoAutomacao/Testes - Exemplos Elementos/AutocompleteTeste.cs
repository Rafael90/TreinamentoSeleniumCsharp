using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class AutocompleteTeste
    {
        [TestMethod]
        public void ExemploGoogleAutocomplete()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.google.com/");

            Thread.Sleep(4000);

            driver.FindElement(By.Name("q")).SendKeys("Estado Sa");

            //Necessário esperar as sugestões serem carregadas
            //Não é o ideal, mas apenas para fins de aprendizado neste momento usaremos o Thread.Sleep
            Thread.Sleep(4000);

            //Armazena a lista de sugestões
            var sugestoes = driver.FindElements(By.XPath("//li[@jsaction='click:.CLIENT;mouseover:.CLIENT']"));

            foreach (var item in sugestoes)
            {
                if (item.Text == "estado santa catarina")
                {
                    item.Click();
                    //Já que a lista não exisitirá após o clique
                    //Usamos o break para sair, caso tente iterar pelo próximo item da lista que não está mais sendo exibida
                    // é lançado o erro StaleElementException,
                    break;
                }
            }
        }

        [TestMethod]
        public void ExemploBatistaMeiaBoca()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/widgets/autocomplete");

            //Elemento possui ID dinâmico, onde apenas o início é mantido como padrão.
            //Assim usamos um xpath que usa a condição de busca 'starts-with'
            driver.FindElement(By.XPath("//input[@data-target[starts-with(.,'autocomplete-options-')]]")).SendKeys("Sa");

            //Necessário esperar as sugestões serem carregadas
            //Não é o ideal, mas apenas para fins de aprendizado neste momento usaremos o Thread.Sleep
            Thread.Sleep(2000);

            var fonte = driver.PageSource;          

            //Armazena a lista de sugestões
            var sugestoes = driver.FindElements(By.ClassName("highlight"));

            foreach (var item in sugestoes)
            {
                Console.WriteLine(item.Text);
                if (item.Text == "santa catarina")
                {
                    item.Click();
                    //Já que a lista não exisitirá após o clique
                    //Usamos o break para sair, caso tente iterar pelo próximo item da lista que não está mais sendo exibida
                    // é lançado o erro StaleElementException,
                    break;
                }
            }

        }
    }
}
