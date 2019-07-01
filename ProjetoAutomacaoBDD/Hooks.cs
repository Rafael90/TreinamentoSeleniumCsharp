using BoDi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using ProjetoAutomacaoBDD.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ProjetoAutomacaoBDD
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private IWebDriver driver;
        private TestContext testContext;
        private readonly IObjectContainer objectContainer;

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        public Hooks(IObjectContainer objectContainer, TestContext test)
        {
            this.objectContainer = objectContainer;
            this.testContext = test;
        }
        
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ScreenshotHelper.CriaPastaEvidencias();
        }

        [BeforeScenario]
        public void BeforeScenario(TestContext test)
        {
            string browser = test.Properties["browser"].ToString();
            driver = CriaDriver(browser);
            driver.Manage().Window.Maximize();
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
            testContext = test;
        }

        [AfterScenario]
        public void AfterScenario(TestContext test)
        {
            //test.AddResultFile(ScreenshotHelper.TiraPrint(ScenarioContext.Current.ScenarioInfo.Title, driver));
            driver.Quit();
            driver.Dispose();
        }

        [AfterStep]
        public void AfterStepWeb(ScenarioContext scenario, TestContext test)
        {
            string tipoPasso = ScenarioContext.Current.StepContext.StepInfo.StepInstance.Keyword.ToString();
            string descricaoPasso = ScenarioContext.Current.StepContext.StepInfo.Text;
            test.AddResultFile(ScreenshotHelper.TiraPrint(tipoPasso + descricaoPasso, driver));
        }


        public IWebDriver CriaDriver(string browser)
        {
            switch (browser.ToUpper())
            {
                case "FIREFOX":
                    driver = new FirefoxDriver();
                    return driver;
                case "CHROMEHEADLESS":
                    var options = new ChromeOptions();
                    options.AddArgument("headless");
                    driver = new ChromeDriver(options);
                    return driver;
                case "CHROME":
                    driver = new ChromeDriver();
                    return driver;
                case "IE":
                    driver = new InternetExplorerDriver();
                    return driver;
                default:
                    throw new AssertFailedException("Driver informado: " + browser + " Informe um driver valido");
            }
        }

    }
}
