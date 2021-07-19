using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Entidades.Database
{
    /// <summary>
    /// Clase abstracta encargada de derivar la informacion y metodos hacia la base de datos.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DataBase_<T> : IDataBase<T>
    {
        protected string connectionString;
        public DataBase_()
        {
            this.connectionString = string.Format($"Server = .; Database = FabricaAutoPartes; Trusted_Connection=True;"); 
        }
        public abstract bool Delete(string input);
        public abstract List<T> GetAll();
        public abstract bool Update(T entity);

    }
}
