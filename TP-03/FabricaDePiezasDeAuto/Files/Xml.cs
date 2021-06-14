using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Files
{
    public class Xml<T> : IFile<T>
    {
        /// <summary>
        /// Metodo que obtiene el directorio Mis documentos..
        /// </summary>
        public string GetDirectoryPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            }
        }

        /// <summary>
        /// Metodo que indicara si un archivo existe o no.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public bool FileExists(string nombreArchivo)
        {
            return File.Exists($"{this.GetDirectoryPath}{nombreArchivo}");
        }

        /// <summary>
        /// Guarda un archivo Xml
        /// </summary>
        /// <param name="file">string</param>
        /// <param name="data">T</param>
        /// <returns> Devuelve true si se pudo guardar y false si no</returns>
        public bool Save(string file, T data)
        {
            bool output = false;
            try
            {
                using (XmlTextWriter tw = new XmlTextWriter($"{this.GetDirectoryPath}{file}", Encoding.UTF8))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(tw, data);
                    output = true;
                }
            }
            catch (FileException e)
            {
                throw new FileException(e);
            }
            return output;
        }

        /// <summary>
        /// Lee un archivo Xml
        /// </summary>
        /// <param name="archivo">string</param>
        /// <param name="datos">out T</param>
        /// <returns> Devuelve true si se pudo Leer y false si no</returns>
        public bool Read(string file, out T data)
        {
            bool output = false;
            try
            {

                if (file.Contains('\\') || !FileExists(file))
                {
                    throw new FileException("Ruta inválida."); //TODO ver exception
                }

                using (XmlTextReader tr = new XmlTextReader($"{this.GetDirectoryPath}{file}"))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    data = (T)ser.Deserialize(tr);
                    output = true;
                }
            }
            catch (FileException e)
            {
                throw new FileException(e);
            }
            return output;
        }


    }
}
