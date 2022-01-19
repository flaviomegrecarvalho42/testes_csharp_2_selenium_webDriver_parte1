using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;

namespace Alura.LeilaoOnline.Selenium.Tests
{
    [Collection("Chrome Driver")]
    public class AoNavegarParaHome 
    {
        private IWebDriver driver;

        //Arrange - Abrir o navegador (Setup)
        public AoNavegarParaHome(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarLeiloesNoTitulo()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Leilões", driver.Title);
        }

        [Fact]
        public void DadoChromeAbertoDeveMostrarProximosLeiloesNaPagina()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            Assert.Contains("Próximos Leilões", driver.PageSource);
        }

        [Fact]
        public void DadoChromeAbertoFormRegistroNaoDeveMostrarMensagensDeErro()
        {
            //arrange

            //act
            driver.Navigate().GoToUrl("http://localhost:5000");

            //assert
            var form = driver.FindElement(By.TagName("form"));
            var spans = form.FindElements(By.TagName("span"));
            foreach (var span in spans)
            {
                Assert.True(string.IsNullOrEmpty(span.Text));
            }
        }
    }
}
