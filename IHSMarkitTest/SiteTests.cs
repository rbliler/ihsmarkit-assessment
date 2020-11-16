using System;
using System.IO;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace IHSMarkitTest
{
    public class SiteTests : IDisposable
    {
        public IWebDriver chromeDriver;
        public DotNetFiddle fiddle;

        public SiteTests()
        {
            try
            {
                // We can add the ChromeDriver using a NuGet package, which allows us to include it in the bin
                // folder when the project is built. In actual dev setup we probably would store this at a known path
                // https://dotnetcoretutorials.com/2019/12/12/things-i-wish-i-knew-about-chromewebdriver-last-week/
                chromeDriver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                chromeDriver.Manage().Window.Maximize();
                chromeDriver.Navigate().GoToUrl("https://dotnetfiddle.net/");
                fiddle = new DotNetFiddle(chromeDriver);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception while setting up test fixture: {e}");
            }
        }

        public void Dispose()
        {
            try
            {
                chromeDriver.Quit();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception while tearing down test fixture: {e}");
            }
        }

        [Fact]
        public void ClickRunBtnAndCheckOutput()
        {
            fiddle.ClickRunBtn();
            // Not the best way (a wait method is better), but slows it down enough for stability
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.Equal("Hello World", fiddle.ConsoleText);
        }

        [Fact]
        public void ClickSaveBtnAndCheckModalDisplay()
        {
            fiddle.ClickSaveBtn();
            // Not the best way (a wait method is better), but slows it down enough for stability
            Thread.Sleep(TimeSpan.FromSeconds(1));
            Assert.True(fiddle.LoginModalDisplayed);
            Assert.Equal("Log in", fiddle.LoginModalTitle);
        }
    }
}
