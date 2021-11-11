using Coypu;
using NUnit.Framework;
using Coypu.Drivers.Selenium;

namespace SeleniumWithCucumber.Tests
{
    public class TestInitial
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
        }


        [TearDown]
        public void Finish()
        {
            browser.Dispose();
        }


        [Test]
        public void Test1()
        {
         
            browser.Visit("/login");
            Assert.AreEqual("Ninja+", browser.Title);
        }

      
    }
}