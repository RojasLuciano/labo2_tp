using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades.Entidades.Files
{
    public class Xml<T> : IFiles<T>
    {
        /// <summary>
        /// MEtodo para leer una cadena de caracteres de un archivo
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public T Read(string file)
        {
            T data = default(T);
            try
            {
                using (XmlTextReader tr = new XmlTextReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\"+file))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    data = (T)ser.Deserialize(tr);
                }
            }
            catch (Exception e)
            {
                throw new FileException("Hubo un error al leer los datos.", e);
            }
            return data;
        }

        /// <summary>
        /// MEtodo para guardar una cadena de caracteres en un archivo
        /// </summary>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Save(string file, T data)
        {
            bool output = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + file, Encoding.UTF8))
                {
                    XmlSerializer ser = new XmlSerializer(typeof(T));
                    ser.Serialize(writer, data);
                    output = true;
                }
            }
            catch (Exception e)
            {
                throw new FileException("Hubo un error al guardar los datos.", e);
            }
            return output;
        }
    }
}
