using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EContact_App
{
    class DBConnection
    {
        public string Mycon()
        {
            string con = @"Data Source=DESKTOP-OUGSDHL\SQLEXPRESS;Initial Catalog=EConDB;Integrated Security=True";
            return con;
        }
    }
}
