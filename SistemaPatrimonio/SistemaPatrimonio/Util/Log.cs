using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SistemaPatrimonio.Util
{
    public class Log
    {

        public static void log(String problema)
        {
           
            string nomeArquivo = @"C:\Users\eduardo\Source\Repos\logPatrimonio\" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".txt";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            writer.WriteLine(problema);
            writer.Close();
        }
        
    }
}