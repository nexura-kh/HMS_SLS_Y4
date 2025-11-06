using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS_SLS_Y4.Data
{
    public static class DatabaseHelper
    {
        public static string ConnectionString =>
            "Server=127.0.0.1;Port=3306;Database=Hostel-DB;Uid=root;Pwd=123456789;";
    }
}
