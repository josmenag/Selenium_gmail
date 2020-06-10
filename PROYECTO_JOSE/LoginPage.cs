using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace PROYECTO_JOSE
{
    class LoginPage
    {
        string test_username = "josmenag.test1@gmail.com";
        string test_password = "123Queso!";
        readonly WebDriverWait wait = new WebDriverWait(Conexion.driver, TimeSpan.FromSeconds(10));

        public void LogIn()
        {
            IWebElement txt_email = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("identifier")));
            IWebElement btn_nextEmail = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("identifierNext")));
                                               
            txt_email.SendKeys(test_username);
            btn_nextEmail.Click();

            Conexion.driver.SwitchTo().ActiveElement();

            IWebElement txt_password = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("password")));
            IWebElement btn_nextPassword = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("passwordNext")));

            txt_password.SendKeys(test_password);
            btn_nextPassword.Click();
        }
    }
}
