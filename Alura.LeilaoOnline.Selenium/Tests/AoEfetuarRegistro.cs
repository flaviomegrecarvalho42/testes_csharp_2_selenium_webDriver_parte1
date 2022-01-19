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
        private IWebDriver driver;

        public AoEfetuarRegistro(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoInformacoesValidasDeveIrParaPaginaDeAgradecimento()
        {
            #region Arrange - Dado navegador aberto, página inicial do sistema de leilões
            //dados de registro válidos informados
            RegistroPageObject registroPageObject = new RegistroPageObject(driver);

            registroPageObject.AbrirHome();
            registroPageObject.PreencherFormulario(nome: "Flavio Carvalho", email: "flavio.megre@gmail.com", password: "123", confirmPassword: "123");
            #endregion

            #region Act - Ao efetuar o registro
            registroPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert - Devo ser direcionado para uma página de agradecimento
            Assert.Contains("Obrigado", driver.PageSource);
            #endregion
        }

        [Theory]
        [InlineData("", "flavio.megre@gmail.com", "123", "123")]
        [InlineData("Flavio Carvalho", "flavio", "123", "123")]
        [InlineData("Flavio Carvalho", "flavio.megre@gmail.com", "123", "456")]
        [InlineData("Flavio Carvalho", "flavio.megre@gmail.com", "", "123")]
        [InlineData("Flavio Carvalho", "flavio.megre@gmail.com", "123", "")]
        public void DadoInformacoesInValidasDeveContinuarNaHomePage(string nome,
                                                                    string email,
                                                                    string password,
                                                                    string confirmPassword)
        {
            #region Arrange - Dado navegador aberto, página inicial do sistema de leilões
            //dados de registro válidos informados
            RegistroPageObject registroPageObject = new RegistroPageObject(driver);

            registroPageObject.AbrirHome();
            registroPageObject.PreencherFormulario(nome: nome, email: email, password: password, confirmPassword: confirmPassword);
            #endregion

            #region Act - Ao efetuar o registro
            registroPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert - Devo ser direcionado para uma página de agradecimento
            Assert.Contains("section-registro", driver.PageSource);
            #endregion
        }

        [Fact]
        public void DadoNomeEmBrancoDeveMostrarMensagemDeErro()
        {
            #region Arrange - Dado navegador aberto, página inicial do sistema de leilões
            //dados de registro válidos informados
            RegistroPageObject registroPageObject = new RegistroPageObject(driver);

            registroPageObject.AbrirHome();
            registroPageObject.PreencherFormulario(nome: "", email: "Flavio", password: "", confirmPassword: "");
            #endregion

            #region Act - Ao efetuar o registro
            registroPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert - Devo ser direcionado para uma página de agradecimento
            Assert.Equal("The Nome field is required.", registroPageObject.MessageErrorNome);
            #endregion
        }

        [Fact]
        public void DadoEmailInvalidoDeveMostrarMensagemDeErro()
        {
            #region Arrange - Dado navegador aberto, página inicial do sistema de leilões
            //dados de registro válidos informados
            RegistroPageObject registroPageObject = new RegistroPageObject(driver);

            registroPageObject.AbrirHome();
            registroPageObject.PreencherFormulario(nome: "", email: "Flavio", password: "", confirmPassword: "");
            #endregion

            #region Act - Ao efetuar o registro
            registroPageObject.SubmeterFormulario();
            Thread.Sleep(1000);
            #endregion

            #region Assert - Devo ser direcionado para uma página de agradecimento
            Assert.Equal("Please enter a valid email address.", registroPageObject.MessageErrorEmail);
            #endregion
        }
    }
}
