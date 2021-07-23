using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Files
{
    public class FileException : Exception
    {
        public FileException()
           : base()
        {
        }

        public FileException(string mensaje): this(mensaje,null)
        {
        }

        public FileException(string mensaje,Exception innerException)
            : base(mensaje, innerException)
        {
        }
    }
}
