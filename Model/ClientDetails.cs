using System.Data;
using System.Threading.Tasks;
using clientApi;
using MySqlConnector;

namespace Model
{
    public class Client
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string contact_number { get; set; }
        public string country { get; set; }
        public string Residential_address { get; set; }
        public string Postal_address { get; set; }
        public string Work_address { get; set; }
        public string Cell_number { get; set; }
        public string Work_number { get; set; }
        public int Client_id { get; set; }


        internal AppDb Db { get; set; }

        public Client()
        {
        }

        internal Client(AppDb db)
        {
            Db = db;
        }

        public async Task InsertAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `ClientList` ( `id`,`name`,`gender`,`email`, `contact_number`,`country`) VALUES (@id,@name, @gender, @email, @contact_number,@country);";
            BindParams(cmd);
            await cmd.ExecuteNonQueryAsync();
            id = (int)cmd.LastInsertedId;
        }
        public async Task DeleteAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `ClientList` WHERE `id` = @id;";
            BindId(cmd);
            await cmd.ExecuteNonQueryAsync();
        }

        private void BindId(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
        }

        private void BindParams(MySqlCommand cmd)
        {
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@name",
                DbType = DbType.String,
                Value = name,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@gender",
                DbType = DbType.String,
                Value = gender,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@email",
                DbType = DbType.String,
                Value = email,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@contact_number",
                DbType = DbType.String,
                Value = email,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@country",
                DbType = DbType.String,
                Value = country,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Client_id",
                DbType = DbType.Int32,
                Value = Client_id,
            });

        }
    }
   
}