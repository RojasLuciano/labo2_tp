using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquinery
{

    public class MachineException : Exception
    {
        public MachineException()
           : base("Hubo una falla en las maquinas.")
        {
        }

        public MachineException(string mensaje)
            : base(mensaje)
        {
        }

        public MachineException(Exception innerException)
            : base("Hubo un error.", innerException)
        {
        }
    }

}
