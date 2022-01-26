using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium;
using System.Threading;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoEfetuarRegistro
    {
        private IWebDriver _driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            _driver = fixture.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimento()
        {
            #region Arrange
            RegistroPageObject registroPageObject = new RegistroPageObject(_driver);

            registroPageObject.AbrirPagina();
            registroPageObject.PreencherFormulario(nome: "Flavio Megre",
                                                   email: "flavio.megre@yahoo.com.br",
                                                   password: "123",
                                                   confirmPassword: "123");
            #endregion

            #region Act
            registroPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert
            Assert.Contains("Obrigado", _driver.PageSource);
            #endregion
        }

        [Theory]
        [InlineData("", "flavio.megre@yahoo.com.br", "123", "123")]
        [InlineData("Flavio Megre", "flavio", "123", "123")]
        [InlineData("Flavio Megre", "flavio.megre@yahoo.com.br", "123", "456")]
        [InlineData("Flavio Megre", "flavio.megre@yahoo.com.br", "", "123")]
        [InlineData("Flavio Megre", "flavio.megre@yahoo.com.br", "123", "")]
        public void DadoInformacoesInValidasDeveContinuarNaHomePage(string nome,
                                                                    string email,
                                                                    string password,
                                                                    string confirmPassword)
        {
            #region Arrange
            RegistroPageObject registroPageObject = new RegistroPageObject(_driver);

            registroPageObject.AbrirPagina();
            registroPageObject.PreencherFormulario(nome: nome, email: email, password: password, confirmPassword: confirmPassword);
            #endregion

            #region Act
            registroPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert
            Assert.Contains("section-registro", _driver.PageSource);
            #endregion
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            #region
            RegistroPageObject registroPageObject = new RegistroPageObject(_driver);

            registroPageObject.AbrirPagina();
            registroPageObject.PreencherFormulario(nome: "", email: "Flavio", password: "", confirmPassword: "");
            #endregion

            #region Act
            registroPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert
            Assert.Equal("The Nome field is required.", registroPageObject.MessageErrorNome);
            #endregion
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            #region Arrange
            RegistroPageObject registroPageObject = new RegistroPageObject(_driver);

            registroPageObject.AbrirPagina();
            registroPageObject.PreencherFormulario(nome: "", email: "Flavio", password: "", confirmPassword: "");
            #endregion

            #region Act
            registroPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert
            Assert.Equal("Please enter a valid email address.", registroPageObject.MessageErrorEmail);
            #endregion
        }
    }
}
