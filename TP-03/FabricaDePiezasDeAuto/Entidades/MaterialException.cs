using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MaterialException : Exception
    {
        public MaterialException()
           : base("Hubo un error. No hay material suficiente")
        {
        }

        public MaterialException(string mensaje)
            : base(mensaje)
        {
        }

        public MaterialException(Exception innerException)
            : base("No hay material suficiente.", innerException)
        {
        }
    }
}
