using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoCamera
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hope you have a great day :)");
            Console.WriteLine("Love you!");

            FirefoxProfile profile = new FirefoxProfile(cfg("profile_dir"));
            FirefoxDriver driver = new FirefoxDriver(profile);
            driver.Url = cfg("url");
            driver.Navigate();
            driver.FindElementById("loginUserName").SendKeys(cfg("username"));
            driver.FindElementById("loginPassword").SendKeys(cfg("password"));
            driver.FindElementById("lalogin").Click();

            var frame = driver.FindElementById("ContentFrame");
            driver.SwitchTo().Frame(frame);
            driver.FindElementById("play").Click();
        }

        static string cfg(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (value == null)
            {
                throw new Exception("Could nto find app setting key: " + key);
            }

            return value;
        }
    }
}
