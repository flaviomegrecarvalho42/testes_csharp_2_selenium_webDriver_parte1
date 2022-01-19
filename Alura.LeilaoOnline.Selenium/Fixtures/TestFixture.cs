using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Alura.LeilaoOnline.Selenium.Fixtures
{
    public class TestFixture : IDisposable
    {
        //Setup
        public TestFixture()
        {
            Driver = new ChromeDriver(TestHelper.PathDoExecutavel);
        }

        public IWebDriver Driver { get; set; }

        //TearDown - Usar o recurso e liberá-lo após o uso
        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
