using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class RegistroPageObject
    {
        private IWebDriver driver;
        private readonly By byFormRegistro;
        private readonly By byInputNome;
        private readonly By byInputEmail;
        private readonly By byInputPassword;
        private readonly By byInputConfirmPassword;
        private readonly By byBtnRegistrar;
        private readonly By bySpanErrorNome;
        private readonly By bySpanErrorEmail;

        public string MessageErrorNome => driver.FindElement(bySpanErrorNome).Text;
        public string MessageErrorEmail => driver.FindElement(bySpanErrorEmail).Text;

        public RegistroPageObject(IWebDriver driver)
        {
            this.driver = driver;
            byFormRegistro = By.TagName("form");
            byInputNome = By.Id("Nome");
            byInputEmail = By.Id("Email");
            byInputPassword = By.Id("Password");
            byInputConfirmPassword = By.Id("ConfirmPassword");
            byBtnRegistrar = By.Id("btnRegistro");
            bySpanErrorNome = By.CssSelector("span.msg-erro[data-valmsg-for=Nome]");
            bySpanErrorEmail = By.CssSelector("span.msg-erro[data-valmsg-for=Email]");
        }

        public void AbrirHome()
        {
            driver.Navigate().GoToUrl("http://localhost:5000");
        }

        public void PreencherFormulario(string nome, string email, string password, string confirmPassword)
        {
            driver.FindElement(byInputNome).SendKeys(nome);
            driver.FindElement(byInputEmail).SendKeys(email);
            driver.FindElement(byInputPassword).SendKeys(password);
            driver.FindElement(byInputConfirmPassword).SendKeys(confirmPassword);
        }

        public void SubmeterFormulario()
        {
            driver.FindElement(byBtnRegistrar).Click();
        }
    }
}
