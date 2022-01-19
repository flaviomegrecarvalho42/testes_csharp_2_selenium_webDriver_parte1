using OpenQA.Selenium;

namespace Alura.LeilaoOnline.Selenium.PageObjects
{
    public class LoginPageObject
    {
        private IWebDriver driver;
        private readonly By byInputLogin;
        private readonly By byInputPassword;
        private readonly By byBtnLogin;

        public LoginPageObject(IWebDriver driver)
        {
            this.driver = driver;
            byInputLogin = By.Id("Login");
            byInputPassword = By.Id("Password");
            byBtnLogin = By.Id("btnLogin");
        }

        public void AbrirPaginaLogin()
        {
            driver.Navigate().GoToUrl("http://localhost:5000/Autenticacao/Login");
        }

        public void PreencherFormulario(string login, string password)
        {
            driver.FindElement(byInputLogin).SendKeys(login);
            driver.FindElement(byInputPassword).SendKeys(password);
        }

        public void SubmeterFormulario()
        {
            driver.FindElement(byBtnLogin).Submit();
        }
    }
}
