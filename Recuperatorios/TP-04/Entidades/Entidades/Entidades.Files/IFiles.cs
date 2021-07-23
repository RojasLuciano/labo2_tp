using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Files
{
    public interface IFiles<T>
    {
        bool Save(string file, T data);
        T Read(string file);
    }
}
