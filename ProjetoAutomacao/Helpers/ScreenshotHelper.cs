using OpenQA.Selenium;
using System;
using System.IO;
using System.Text;

namespace ProjetoAutomacao.Helpers
{
    class ScreenshotHelper
    {
        public static string TiraPrint(string nomeDaImagem, IWebDriver driver)
        {
            StringBuilder timeStamp = new StringBuilder(DateTime.Now.ToString());
            timeStamp.Replace("/", "_");
            timeStamp.Replace(":", "_");

            string caminhoAssembly = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            caminhoAssembly = new Uri(caminhoAssembly).LocalPath;
            string novoCaminho = Path.GetFullPath(Path.Combine(caminhoAssembly, @"../../../"));
            string caminhoDaFoto = novoCaminho + "Evidencias\\" + nomeDaImagem + "_" + timeStamp + ".jpeg";

            ITakesScreenshot camera = driver as ITakesScreenshot;
            Screenshot foto = camera.GetScreenshot();

            foto.SaveAsFile(caminhoDaFoto, ScreenshotImageFormat.Jpeg);

            return caminhoDaFoto;
        }

        public static void CriaPastaEvidencias()
        {
            string caminhoAssembly = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            caminhoAssembly = new Uri(caminhoAssembly).LocalPath;
            string novoCaminho = Path.GetFullPath(Path.Combine(caminhoAssembly, @"../../../"));
            string caminhoFinal = novoCaminho + "Evidencias\\";
            DirectoryInfo Pasta = new DirectoryInfo(caminhoFinal);
            if (Pasta.Exists != true)
            {
                Pasta.Create();
            }
        }


    }
}
