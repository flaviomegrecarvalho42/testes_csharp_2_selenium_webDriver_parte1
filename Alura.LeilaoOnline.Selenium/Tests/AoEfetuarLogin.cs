using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoEfetuarLogin
    {
        private IWebDriver _driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaPaginaDashboard()
        {
            #region Arrange
            LoginPageObject loginPageObject = new LoginPageObject(_driver);

            loginPageObject.AbrirPagina();
            loginPageObject.PreencherFormulario(login: "fulano@example.org", password: "123");
            #endregion

            #region Act
            loginPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert
            Assert.Contains("Dashboard", _driver.Title);
            #endregion
        }

        [Fact]
        public void DadoCredenciaisInValidasDeveContinuarNaPaginaDeLogin()
        {
            #region Arrange
            LoginPageObject loginPageObject = new LoginPageObject(_driver);

            loginPageObject.AbrirPagina();
            loginPageObject.PreencherFormulario(login: "fulano@example.org", password: "");
            #endregion

            #region Act
            loginPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert
            Assert.Contains("Login", _driver.PageSource);
            #endregion
        }
    }
}
