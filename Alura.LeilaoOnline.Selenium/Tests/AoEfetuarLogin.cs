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
        private IWebDriver driver;

        public AoEfetuarLogin(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoCredenciaisValidasDeveIrParaPaginaDashboard()
        {
            #region Arrange - Dado navegador aberto, página inicial do sistema de leilões
            //dados de registro válidos informados
            LoginPageObject loginPageObject = new LoginPageObject(driver);

            loginPageObject.AbrirPaginaLogin();
            loginPageObject.PreencherFormulario(login: "flavio.megre@gmail.com", password: "123");
            #endregion

            #region Act - Ao efetuar o registro
            loginPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert - Devo ser direcionado para uma página de agradecimento
            Assert.Contains("Dashboard", driver.Title);
            #endregion
        }

        [Fact]
        public void DadoCredenciaisInValidasDeveContinuarNaPaginaDeLogin()
        {
            #region Arrange - Dado navegador aberto, página inicial do sistema de leilões
            //dados de registro válidos informados
            LoginPageObject loginPageObject = new LoginPageObject(driver);

            loginPageObject.AbrirPaginaLogin();
            loginPageObject.PreencherFormulario(login: "flavio.megre@gmail.com", password: "");
            #endregion

            #region Act - Ao efetuar o registro
            loginPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert - Devo ser direcionado para uma página de agradecimento
            Assert.Contains("Login", driver.PageSource);
            #endregion
        }
    }
}
