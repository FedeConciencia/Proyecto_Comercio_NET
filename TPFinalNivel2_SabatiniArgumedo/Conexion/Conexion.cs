using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class Conexion
    {
        public static SqlConnection ConexionBD()
        {

            SqlConnection connection;
            string server = "NBK-FSABATINI";
            string database = "CATALOGO_DB";
            string usuario = "";
            string password = "";

            connection = new SqlConnection("server=" + server + "; database=" + database + "; integrated security=true");

            return connection;

        }
    }
}
