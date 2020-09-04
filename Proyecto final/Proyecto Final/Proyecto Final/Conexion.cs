using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Proyecto_Final
{
    class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("Server=LAPTOP-20N6S7NM;DATABASE=Unitec;Integrated Security=True");
            cn.Open();
            return cn;

        }
    }
}
