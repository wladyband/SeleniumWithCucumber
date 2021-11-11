using Coypu;
using Coypu.Drivers.Selenium;
using NUnit.Framework;
using System.Threading;

namespace SeleniumWithCucumber.Tests
{
    public class LoginTests
    {

        public BrowserSession browser;

        [SetUp]
        public void Setup()
        {
            var config = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome
            };

            browser = new BrowserSession(config);
            browser.MaximiseWindow();
        }


        [TearDown]
        public void Finish()
        {
            browser.Dispose();
        }

        [Test]
        public void SucessfullyLogin() {
            browser.Visit("/login");
            browser.FillIn("email").With("papito@ninjaplus.com");
            browser.FindCss("input[placeholder=senha]").SendKeys("pwd123");
            browser.ClickButton("Entrar");

            Thread.Sleep(5000);
            var loggedUser = browser.FindCss(".user .info span");
            Assert.AreEqual("Papito", loggedUser.Text);
            
        }
    }
}
