using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using Settings;


namespace ItemActions
{
    public class Helpers
    {
        //private IWebDriver _driver;
        //private string _username;
        //private string _password;
        //public Helpers()
        //{
            //_driver = TestSettings.Driver;
            //Console.Out.WriteLine(_driver);
            //_username = ConfigurationManager.AppSettings["username"];
            //_password = ConfigurationManager.AppSettings["password"];
        //}

        //public void Login()
        //{
        //    Set(Locators.Username, _username);
        //    Set(Locators.Password, _password);
        //    PressLoginBtn();
        //}

        //public void Set(string fieldname, string credential)
        //{
        //    IWebElement input = _driver.FindElement(By.CssSelector(fieldname));
        //    input.Clear();
        //    input.SendKeys(credential);
        //}

        //public void PressLoginBtn()
        //{
        //    _driver.FindElement(By.CssSelector(Locators.LoginBtn)).Click();
        //}



    }
}
