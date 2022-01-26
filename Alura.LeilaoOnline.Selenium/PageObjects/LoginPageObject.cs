using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPageObject
    {
        private IWebDriver _driver;
        private readonly By byInputLogin;
        private readonly By byInputPassword;
        private readonly By byButtonLogin;

        public LoginPageObject(IWebDriver driver)
        {
            this._driver = driver;
            byInputLogin = By.Id("Login");
            byInputPassword = By.Id("Password");
            byButtonLogin = By.Id("btnLogin");
        }

        public void AbrirPagina()
        {
            _driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencherFormulario(string login, string password)
        {
            _driver.FindElement(byInputLogin).SendKeys(login);
            _driver.FindElement(byInputPassword).SendKeys(password);
        }

        public void SubmeterFormulario()
        {
            _driver.FindElement(byButtonLogin).Submit();
        }
    }
}
