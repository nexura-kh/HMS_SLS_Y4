using HMS_SLS_Y4.Data;
using HMS_SLS_Y4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Repositories
{
    internal class ToyRepository : BaseRepository<User>
    {
        public ToyRepository(string connectionString) : base(DatabaseHelper.ConnectionString)
        {
        }

        public override int Add(User entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public override List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public override User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public override bool Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
