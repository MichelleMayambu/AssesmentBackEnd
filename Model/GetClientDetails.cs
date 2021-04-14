using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using clientApi;
using ClientsApi;
using Model;
using MySqlConnector;

namespace ClientsApi
{
    //https://mysqlconnector.net/tutorials/net-core-mvc/
    public class ClientsPostQuery
    {
        public AppDb Db { get; }


        public ClientsPostQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<Client> FindOneAsync(int id)
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `id`, `name`, `gender`,`email`, `contact_number`,`country` FROM `ClientList` WHERE `id` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<Client>> LatestPostsAsync()
        {
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT `ClientList`.id, `ClientList`.name, `ClientList`.gender,`ClientList`.email,
             `ClientList`.contact_number,`ClientList`.country,
             `ClientAddress`.Residential_address, 
              `ClientAddress`.Postal_address,
               `ClientAddress`.Work_address,
                    `ClientAddress`.Cell_number,
                 `ClientAddress`.Work_number,
                   `ClientAddress`.Client_id
             FROM `ClientList` 
             INNER JOIN `ClientAddress` ON `ClientList`.id = `ClientAddress`.Client_id";
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }

        public async Task DeleteAllAsync()
        {
            using var txn = await Db.Connection.BeginTransactionAsync();
            using var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"DELETE FROM `Client`";
            await cmd.ExecuteNonQueryAsync();
            await txn.CommitAsync();
        }

        private async Task<List<Client>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<Client>();
            using (reader)
            {
       
                while (await reader.ReadAsync())
                {
                    var post = new Client(Db)
                    {
                        id = reader.GetInt32(0),
                        name = reader.GetString(1),
                        gender = reader.GetString(2),
                        contact_number = reader.GetString(3),
                        country = reader.GetString(4),
                        email = reader.GetString(5),
                        Residential_address = reader.GetString(6),
                        Postal_address = reader.GetString(7),
                        Cell_number = reader.GetString(8),
                        Work_number = reader.GetString(9),
                        Work_address = reader.GetString(10),
                        Client_id = reader.GetInt32(11),
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}