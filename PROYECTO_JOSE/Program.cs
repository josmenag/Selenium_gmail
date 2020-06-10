using NUnit.Framework;
using OpenQA.Selenium.Remote;
using System;

namespace PROYECTO_JOSE
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Inicializar()
        {
            Conexion conexion = new Conexion();
            conexion.SetUpBrowser();
        }

        [Test]
        public void Ejecutar()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.LogIn();

            Dashboard dash = new Dashboard();
            dash.Aprender(); 
            dash.DescargarMovil(); 
            dash.ElegirUnTema();
            dash.ImportarContactos(); 
            dash.CambiarImagen();
            dash.EnviarCorreo();
            dash.TomarScreenshot();
            dash.EliminarCorreo();
            //dash.CerrarSesion();
        }

        [TearDown]
        public void Finalizar()
        {
            Conexion.driver.Close();
        }        
    }
}
