using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AssesmentApi.Model;
using ClientApi;
using Dapper;
using Model;
using MySqlConnector;

namespace clientApi
{
    public class AppDb 
    {
        internal AppDb Db { get; set; }
        public MySqlConnection Connection { get; }
        public static object CommonData { get; private set; }

        public AppDb(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
            //Connection.Open();
        }
        public void Dispose() => Connection.Dispose();
    
        }

        //public void Dispose() => Connection.Close();
}