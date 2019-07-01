using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ProjetoAutomacao.Testes_Exemplos_Elementos
{
    [TestClass]
    public class RadioTeste
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://www.facebook.com/");

            bool selecionadoFeminino;
            bool selecionadoMasculino;

            //Radiobutton Feminino
            driver.FindElement(By.Id("u_0_9")).Click();
            Console.WriteLine("Click no Radiobutton Feminino");

            selecionadoFeminino = driver.FindElement(By.Id("u_0_9")).Selected;
            selecionadoMasculino = driver.FindElement(By.Id("u_0_a")).Selected;
            Console.WriteLine("Feminino : " + selecionadoFeminino + " Masculino : " + selecionadoMasculino);

            //Radiobutton Masculino
            driver.FindElement(By.Id("u_0_a")).Click();
            Console.WriteLine("Click no Radiobutton Masculino");

            selecionadoFeminino = driver.FindElement(By.Id("u_0_9")).Selected;
            selecionadoMasculino = driver.FindElement(By.Id("u_0_a")).Selected;

            Console.WriteLine("Feminino : " + selecionadoFeminino + " Masculino : " + selecionadoMasculino);

        }
    }
}
