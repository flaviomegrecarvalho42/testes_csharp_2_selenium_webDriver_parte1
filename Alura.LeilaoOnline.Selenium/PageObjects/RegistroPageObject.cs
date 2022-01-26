using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPageObject
    {
        private IWebDriver _driver;
        private readonly By byFormRegistro;
        private readonly By byInputNome;
        private readonly By byInputEmail;
        private readonly By byInputPassword;
        private readonly By byInputConfirmPassword;
        private readonly By byButtonRegistrar;
        private readonly By bySpanErrorNome;
        private readonly By bySpanErrorEmail;

        public string MessageErrorNome => _driver.FindElement(bySpanErrorNome).Text;
        public string MessageErrorEmail => _driver.FindElement(bySpanErrorEmail).Text;

        public RegistroPageObject(IWebDriver driver)
        {
            this._driver = driver;
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputPassword = By.Id("Password");
            byInputConfirmPassword = By.Id("ConfirmPassword");
            byButtonRegistrar = By.Id("btnRegistro");
            bySpanErrorNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            bySpanErrorEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        public void AbrirPagina()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void PreencherFormulario(string nome, string email, string password, string confirmPassword)
        {
            _driver.FindElement(byInputNome).SendKeys(nome);
            _driver.FindElement(byInputEmail).SendKeys(email);
            _driver.FindElement(byInputPassword).SendKeys(password);
            _driver.FindElement(byInputConfirmPassword).SendKeys(confirmPassword);
        }

        public void SubmeterFormulario()
        {
            _driver.FindElement(byButtonRegistrar).Click();
        }
    }
}
