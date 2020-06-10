using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System.Linq;
using NUnit.Framework.Internal;
using OpenQA.Selenium.Interactions;

namespace PROYECTO_JOSE
{
    class Dashboard
    {
        readonly WebDriverWait wait = new WebDriverWait(Conexion.driver, TimeSpan.FromSeconds(10));

        public void Aprender()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Conexion.driver;

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("#\\:2j\\.at_gt")));
            IWebElement lbl_aprende = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("#\\:2j\\.at_gt")));
            lbl_aprende.Click();
            Thread.Sleep(2000);
            Conexion.driver.SwitchTo().Frame(Conexion.driver.FindElement(By.Id("google-feedback-wizard")));
            Conexion.driver.SwitchTo().Frame(Conexion.driver.FindElement(By.Id("google-help-content-frame")));

            Thread.Sleep(2000);

            IWebElement scrollFrame = Conexion.driver.FindElement(By.XPath("//*[@id='content']/div"));
            js.ExecuteScript("arguments[0].scrollIntoView(false)", scrollFrame);

            Thread.Sleep(2000);

            Conexion.driver.SwitchTo().DefaultContent();
            Conexion.driver.SwitchTo().Frame(Conexion.driver.FindElement(By.Id("google-feedback-wizard")));

            IWebElement btn_closeAprender = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='header']/div[1]/button")));
            Thread.Sleep(2000);

            btn_closeAprender.Click();

            Conexion.driver.SwitchTo().DefaultContent();
        }

        public void DescargarMovil()
        {
            //Descarga Gmail para móviles:Seleccionar la opción y luego cerrar el PopUp.
            IWebElement lbl_descargarMovil = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=':2j.at_gfm']")));
            
            Thread.Sleep(2000);

            lbl_descargarMovil.Click();
            Thread.Sleep(2000);

            IWebElement btn_closeDescargar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > div.Kj-JD.a0b > div.Kj-JD-K7 > span.Kj-JD-K7-Jq")));
            btn_closeDescargar.Click();
        }

        public void ElegirUnTema()
        {
            //Elige un tema:Seleccionar la opción,luego seleccionar la imagen que más nos gustey finalmente guardar la selección.
            IWebElement btn_eligirUnTema = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//*[@id=':2j.at_th']")));
            btn_eligirUnTema.Click();

            Conexion.driver.SwitchTo().ActiveElement();

            IWebElement imagen = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("div.a7H")));
            
            imagen.Click();
            imagen.Click();
            Thread.Sleep(2000);
            Actions action = new Actions(Conexion.driver);
            action.SendKeys(Keys.Right).Release();
            action.SendKeys(Keys.Right).Release(); 
            action.SendKeys(Keys.Enter).Release().Build().Perform();
            Thread.Sleep(2000);

            IWebElement btn_cerrar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("body > div.Kj-JD.a8j > div.Kj-JD-Jl.a8Y > div.J-J5-Ji.T-I.T-I-atl")));
            btn_cerrar.Click();

            Conexion.driver.SwitchTo().DefaultContent();
        }

        public void ImportarContactos() {
            //Importa contactos y mensajes: Seleccionar la opción, escribir un correo y luego cerrar la ventana emergente
            IWebElement btn_importarContactos = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("div#\\:2j\\.at_im > .a50")));
            btn_importarContactos.Click();

            Conexion.driver.SwitchTo().Window(Conexion.driver.WindowHandles.Last());

            Thread.Sleep(1000);

            IWebElement lbl_correo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html//input[@id=':rn']")));
            lbl_correo.SendKeys("Test@test.com");

            Thread.Sleep(1000);

            Conexion.driver.Close();
            Conexion.driver.SwitchTo().Window(Conexion.driver.WindowHandles.Last());
        }

        public void CambiarImagen()
        {
            var path = "C:\\Archivos\\photo.jpeg"; 

            IWebElement subirFoto = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(":2j.at_cpp")));
            subirFoto.Click();
            Thread.Sleep(4000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.CssSelector("div.Kj-JD-Jz > iframe")));

            Thread.Sleep(2000);
            IWebElement input_send = Conexion.driver.FindElement(By.CssSelector("div.ve-Fc-Xe-td-u input"));
            Thread.Sleep(4000);

            input_send.SendKeys(path);

            Thread.Sleep(6000);

            IWebElement esquina1 = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id='doclist']/div/div[4]/div[2]/div/div[2]/div/div[2]/div[1]/div/div[2]/div/div[2]/div/div[1]/div/div[2]")));
            
            Actions action = new Actions(Conexion.driver);

            action.ClickAndHold(esquina1);
            action.Release(esquina1).Perform();

            IWebElement btn_establecerFotoPerfil = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='doclist']/div/div[4]/div[2]/div/div[2]//div[@class='ve-Li-ic ve-Mi-ie']/div[@class='ve-Mi-Si-pe']/div/div[1]")));
            btn_establecerFotoPerfil.Click();

            Thread.Sleep(4000);

            Conexion.driver.SwitchTo().DefaultContent();
            Thread.Sleep(2000);

        }

        public void TomarScreenshot()
        {
            try
            {
                Screenshot ss = ((ITakesScreenshot)Conexion.driver).GetScreenshot();
                ss.SaveAsFile("C:\\Archivos\\screenshot.jpg");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void EliminarCorreo()
        {
            IWebElement correo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[2]/div/div/div/div/div[2]/div/div[1]/div/div/div[7]/div/div[1]/div[3]/div/table/tbody/tr[1]/td[5]")));
            IWebElement mas = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body[@class='aAU']/div[7]/div[3]/div[@class='nH']/div[2]/div[@class='no']/div[1]//div[@class='aj9 pp']/div[@class='oo']//div[@role='navigation']//span[@role='button']")));
            Thread.Sleep(1200);
            mas.Click();
            Thread.Sleep(2000);

            IWebElement crearNuevaEtiqueta = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[1]/div[1]/div/div/div/div[2]/div/div/div[3]/div/div[8]/a")));

            IJavaScriptExecutor js = (IJavaScriptExecutor)Conexion.driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true)", crearNuevaEtiqueta);
            Thread.Sleep(2000);
            IWebElement papelera = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText("Papelera")));

            Actions action = new Actions(Conexion.driver);
            action.ClickAndHold(correo);
            action.MoveToElement(papelera);
            Thread.Sleep(1000);
            action.MoveToElement(papelera);
            action.Release(papelera).Perform();

            Thread.Sleep(3000);
        }

        public void EnviarCorreo()
        {
            IWebElement btn_redactar = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html/body[@class='aAU']/div[7]/div[3]/div[@class='nH']//div[@class='aj9 pp']/div[@class='oo']//div[@class='aic']//div[@role='button']")));
            btn_redactar.Click();

            IWebElement txt_para = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("to")));
            //txt_para.SendKeys("maritzaguilarce@hotmail.com");
            txt_para.SendKeys("josmenag@gmail.com");

            IWebElement txt_asunto = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name("subjectbox")));
            txt_asunto.SendKeys("Proyecto Final-JOSE");

            IWebElement txt_cuerpo = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("div.Am.Al.editable.LW-avf.tS-tW")));
            txt_cuerpo.SendKeys("El curso me ha parecido muy interesante. Me gusta el enfoque muy practico que se le da.");

            var path = "C:\\Archivos\\test.pdf";

            IWebElement input_send = Conexion.driver.FindElement(By.Name("Filedata"));
            Thread.Sleep(4000);

            input_send.SendKeys(path);

            IWebElement sendEmail = Conexion.driver.FindElement(By.CssSelector("div[data-tooltip*='Enviar']"));
            sendEmail.Click();
            Thread.Sleep(3000);
        }

        public void CerrarSesion()
        {
            IWebElement btn_cuenta = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("/html//header[@id='gb']/div[2]/div[3]/div[@class='gb_3c']/div[2]/div/a[@role='button']/span[@class='gb_Ia gbii']")));
            btn_cuenta.Click();            
        }
    }
}
