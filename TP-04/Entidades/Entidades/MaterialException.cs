using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MaterialException : Exception
    {
        public MaterialException() : base() { }

        public MaterialException(string mensaje) : this(mensaje, null) { }

        public MaterialException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
    }
}