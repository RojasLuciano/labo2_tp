using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Database
{
  public interface  IDataBase<T>
    {
        List<T> GetAll();
        bool Delete(string input);
        bool Update(T entity);
    }
}
