using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using ProjetoAutomacao.Helpers;

namespace ProjetoAutomacao
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver;
        //Não alterar a forma como TestContext está declarado, caso contrário não irá funcionar
        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            ScreenshotHelper.CriaPastaEvidencias();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            string browser = TestContext.Properties["browser"].ToString();
            driver = CriaDriver(browser);
            driver.Manage().Window.Maximize();
            //Espera Implicita
            //int implicitTimeout = Convert.ToInt32(TestContext.Properties["timeoutImplicito"]);
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitTimeout);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.AddResultFile( ScreenshotHelper.TiraPrint(TestContext.TestName + "_Imagem_Final", driver) );
            driver.Quit();
            driver.Dispose();
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
