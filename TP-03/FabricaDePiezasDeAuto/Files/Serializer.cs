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
    public class Serializer
    {
        /// <summary>
        /// Metodo que obtiene el directorio Mis documentos..
        /// </summary>
        public static string GetDirectoryPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\";
            }
        }

        /// <summary>
        /// Metodo que indicara si un archivo existe o no.
        /// </summary>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public static bool FileExists(string nombreArchivo)
        {
            return File.Exists($"{GetDirectoryPath}{nombreArchivo}");
        }

        /// <summary>
        /// Metodo que serializara un objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="fullPath"></param>
        public static void SerializeToFile<T>(T obj, string fullPath) where T : class, new()
        {
            try
            {
                using (var stream = new FileStream($"{GetDirectoryPath}{fullPath}", FileMode.Create))
                using (var writer = new XmlTextWriter(stream, Encoding.Unicode))
                {
                    var xmlSerializer = new XmlSerializer(obj.GetType());
                    xmlSerializer.Serialize(writer, obj);
                }
            }
            catch (FileException e)
            {
                throw new FileException(e.Message);
            }
        }

        /// <summary>
        /// Metodo que deserealizara un objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static T DeserializeFromFile<T>(string fullPath) where T : class, new()
        {
            try
            {

                if (!FileExists(fullPath))
                {
                    throw new Exception("Ruta inválida."); //TODO ver exception
                }
                using (var stream = new FileStream($"{GetDirectoryPath}{fullPath}", FileMode.Open))
                {
                    var xmlSerializer = new XmlSerializer(typeof(T));
                    return (T)xmlSerializer.Deserialize(stream);
                }

            }
            catch (FileException e)
            {
                throw new FileException(e.Message); //TODO arreglar excepciones
            }

#pragma warning disable CS0162 // Se detectó código inaccesible
            return default(T);
#pragma warning restore CS0162 // Se detectó código inaccesible
        }


    }
}
