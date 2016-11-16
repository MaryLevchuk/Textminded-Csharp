using System;
using System.Configuration;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using RestSharp;

namespace Settings
{
    public abstract class TestSettings
    {
        //public RestClient Client;
       
        //public TestSettings()
        //{
        //    Client = new RestClient("http://api.testrdb.arla.com");
            //Request = new RestRequest("/foodservice-fi/translation/recipe", Method.GET);
            //Request.AddHeader("auth_apikey", ConfigurationManager.AppSettings["auth_apikey"]);
        }


        //public static IWebDriver Driver;

        //public const string FIREFOX = "firefox";
        //public const string IEXPLORER = "iexplore";
        //public const string CHROME = "chrome";

        //public IWebDriver SetBrowser(string browser)
        //{
        //    IWebDriver driver;
        //    switch (browser)
        //    {
        //        case FIREFOX:
        //            driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
        //            break;
        //        case IEXPLORER:
        //            driver = new OpenQA.Selenium.IE.InternetExplorerDriver();
        //            break;
        //        case CHROME:
        //            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        //            break;
        //        default:
        //            throw new Exception();
        //    }
        //    return driver;
        //}

        //public void OpenBrowser(string browser)
        //{
        //    Driver = SetBrowser(browser);
        //    Driver.Manage().Window.Maximize();
        //}
        //public TestSettings(string driver)
        //{
        //    OpenBrowser(driver);
        //}

        //public void OpenPageByUrl(string url)
        //{
        //    Driver.Navigate().GoToUrl(url);
        //    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        //}


        //[TestFixtureTearDown]
        //public void CloseBrowser()
        //{
        //    Thread.Sleep(1000);
        //    Driver.Quit();
        //}
    
}
