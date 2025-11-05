using HMS_SLS_Y4.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected string ConnectionString { get; set; }

        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public abstract int Add(T entity);
        public abstract List<T> GetAll();
        public abstract T GetById(int id);
        public abstract bool Update(T entity);
        public abstract bool Delete(int id);
    }
}
