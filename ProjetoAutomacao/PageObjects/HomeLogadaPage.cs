using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace ProjetoAutomacao.PageObjects
{
    class HomeLogadaPage : BasePage
    {
        public HomeLogadaPage(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.CssSelector, Using = ".account")]
        private IWebElement lnkNomeUsuario { get; set; }

        public string VerificaHomeLogada()
        {
            return lnkNomeUsuario.Text;
        }

    }
}
