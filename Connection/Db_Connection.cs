using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Backend_API_UltraGym.Connection
{
    public class Db_Connection
    {
        public static SqlConnection ConexionSQL()
        {
            SqlConnection ConnectionStrings = new SqlConnection(
                "Server=tcp:genesis-server.database.windows.net,1433;" +
                "Initial Catalog=database-ultra_gym;" +
                "Persist Security Info=False;" +
                "User ID=alejandroS;" +
                "Password=MasterSource22;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;");

            return ConnectionStrings;
        }


        public static DataTable ReaderDatabase(string Query)
        {
            var ResultSet = new DataTable();

            var Connect = ConexionSQL();
            Connect.Open();

            var QueryCommand = new SqlCommand(Query, Connect);
            
            var Adapter = new SqlDataAdapter(QueryCommand);
            //CREAMOS UN ADAPTADOR PARA LA CONSULTA
            
            Adapter.Fill(ResultSet);

            Connect.Close();

            return ResultSet;

        }

      
    }
}
