using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROYECTO_JOSE
{
    class Conexion
    {
        public static IWebDriver driver { get; set; }

        public void SetUpBrowser()
        {
            driver = null;

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");
            options.AddArgument(@"--incognito");
                        
            driver = new ChromeDriver(options)
            {
                Url = "https://www.gmail.com"
            };
            driver.Navigate();
        }
    }
}
