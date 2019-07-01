using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ProjetoAutomacaoBDD.PageObjects
{
    class HomeNaoLogadaPage : BasePage
    {
        public HomeNaoLogadaPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.XPath, Using = "//a[@href='http://automationpractice.com/index.php?controller=my-account']")]
        private IWebElement lnkSignIn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='http://automationpractice.com/index.php?controller=contact']")]
        private IWebElement lnkContactUs { get; set; }

        public LoginPage AcessarLogin()
        {
            lnkSignIn.Click();
            return new LoginPage(driver);
        }

        public HomeNaoLogadaPage AcessarContactUs()
        {
            lnkContactUs.Click();
            return this;
        }

    }

}
