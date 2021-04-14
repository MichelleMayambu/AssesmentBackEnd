using clientApi;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AssesmentApi.Model
{
    public class ClientAddress
    {
        public int id { get; set; }
        public string Residential_address { get; set; }
        public string Postal_address { get; set; }
        public string Work_address { get; set; }
        public string Cell_number { get; set; }
        public string Work_number { get; set; }
        public int Client_id { get; set; }

        internal AppDb Db { get; set; }

        public ClientAddress()
        {
        }

        internal ClientAddress(AppDb db)
        {
            Db = db;
        }
      
        public async Task InsertClientAddressAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO `ClientAddress` (`id`,`Residential_address`,`Postal_address`,`Work_address`,
           `Cell_number`, `Work_number`,`Client_id`) 
            VALUES (@id,@Residential_address, @Postal_address, @Work_address, @Cell_number, @Work_number,@Client_id);";
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
                ParameterName = "@Residential_address",
                DbType = DbType.String,
                Value = Residential_address,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Postal_address",
                DbType = DbType.String,
                Value = Postal_address,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Work_address",
                DbType = DbType.String,
                Value = Work_address,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Cell_number",
                DbType = DbType.String,
                Value = Cell_number,
            });
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@Work_number",
                DbType = DbType.String,
                Value = Work_number,
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
