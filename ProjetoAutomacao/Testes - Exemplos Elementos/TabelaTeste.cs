using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class TabelaTeste
    {
        [TestMethod]
        public void TestMethod1()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://automacaocombatista.herokuapp.com/buscaelementos/table");

            //Armazena a tabela
            var table = driver.FindElement(By.TagName("table"));

            //Realiza uma busca encadeada a partir da tabela (table.findelemnts), onde são buscadas as linhas da tabela
            //Utilizando o FindElementS que retorna uma lista de objetos
            //No FindElements caso nenhum elemento seja encontrado retorna uma lista vazia sem dar erro
            var rows = table.FindElements(By.TagName("tr"));
            //Percorre pelas linhas encontradas
            foreach (var row in rows)
            {
                //Realiza uma busca encadeada apartir da linha atual, onde são buscadas as células individualmente
                var rowTds = row.FindElements(By.TagName("td"));
                //Itera por cada célula imprimindo seu conteúdo
                foreach (var td in rowTds)
                {
                    Console.Write(" | " + td.Text);
                }
                //Quebra de linha no output antes de buscar uma nova linha da tabela.
                Console.WriteLine("\n");
            }
        }
    }
}
