using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Files
{
    public class Txt<T> : IFiles<T>
    {
        /// <summary>
        /// MEtodo para leer una cadena de caracteres de un archivo
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public T Read(string file)
        {
            T data = default(T);

            if (File.Exists(file))
            {
                using (StreamReader sr = new StreamReader(file))
                {
                   data = (T)Convert.ChangeType(sr.ReadToEnd(), typeof(T));
                }
            }
            else
            {
                throw new FileNotFoundException();
            }
            return data;
        }
        /// <summary>
        /// MEtodo para guardar una cadena de caracteres de un archivo
        /// </summary>
        /// <param name="file"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Save(string file, T data)
        {
            bool output = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(file, true))
                {
                    sw.WriteLine(data.ToString());
                    sw.Close();
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
