using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Files
{
    public class Logger
    {
        private IFiles<string> archivoTemporal;
        private string filePath;

        /// <summary>
        /// Constructor de la clase logger
        /// </summary>
        /// <param name="path"></param>
        public Logger(string path)
        {
            this.archivoTemporal = new Txt<string>();
            this.filePath = path;
        }

        /// <summary>
        /// Metodo que recibe una excepcion y la agrega al archivo de logs.
        /// </summary>
        /// <param name="e"></param>
        public void saveReport(Exception e)
        {
            try
            {
                archivoTemporal.Save(filePath, e.ToString());
            }
            catch (Exception ex)
            {
                throw new FileException("Hubo un error guardando el reporte.", ex);
            }
        }
        /// <summary>
        /// Metodo que abre un archivo y realiza su lectura.
        /// </summary>
        /// <returns></returns>
        public string readReport()
        {
            string output = String.Empty;
            string contenidoReporte = String.Empty;
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Bitacora de errores:");
                archivoTemporal.Read(filePath);
                sb.Append(contenidoReporte);
                output = sb.ToString();

            }
            catch (FileException)
            {
                output = "Hubo problemas al abrir el archivo";
            }
            return output;
        }
    }
}
