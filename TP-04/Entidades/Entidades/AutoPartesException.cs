using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AutoPartesException : Exception
    {

        public AutoPartesException() : base() { }

        public AutoPartesException(string mensaje) : this(mensaje, null) { }

        public AutoPartesException(string mensaje, Exception innerException) : base(mensaje, innerException) { }
    }
}