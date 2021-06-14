using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    public class FileException : Exception
    {
        public FileException()
           : base("Archivo Inexistente")
        {
        }

        public FileException(string mensaje)
            : base(mensaje)
        {
        }

        public FileException(Exception innerException)
            : base("Archivo Inexistente", innerException)
        {
        }
    }
}
