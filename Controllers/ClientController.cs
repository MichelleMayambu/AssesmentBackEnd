using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AssesmentApi.Model;
using clientApi;
using ClientApi;
using ClientsApi;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace ClientApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        //private readonly ConnectionStrings connectionStrings;
        public ClientController(AppDb db)
        {
            Db = db;
        }
       
   

        // GET api/clients
        [HttpGet("GetClientList")]
        public async Task<IActionResult> GetClientList()
        {
            await Db.Connection.OpenAsync();
            var query = new ClientsPostQuery(Db);
            var result = await query.LatestPostsAsync();
            return new OkObjectResult(result);
        }
        [HttpGet]
        public string Test()
        {
            return "you have hit the client api";
        }
        // GET api/client/5
        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new ClientsPostQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            return new OkObjectResult(result);
        }

        // POST api/client
        [HttpPost("AddClient")]
        public async Task<IActionResult> AddClient([FromBody] Client body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertAsync();
            return new OkObjectResult(body);
        }
        // POST api/client
        [HttpPost("AddClientAddress")]
        public async Task<IActionResult> AddClientAddress([FromBody] ClientAddress body)
        {
            await Db.Connection.OpenAsync();
            body.Db = Db;
            await body.InsertClientAddressAsync();
            return new OkObjectResult(body);
        }

        // DELETE api/client/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOne(int id)
        {
            await Db.Connection.OpenAsync();
            var query = new ClientsPostQuery(Db);
            var result = await query.FindOneAsync(id);
            if (result is null)
                return new NotFoundResult();
            await result.DeleteAsync();
            return new OkResult();
        }

        // DELETE api/client
        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await Db.Connection.OpenAsync();
            var query = new ClientsPostQuery(Db);
            await query.DeleteAllAsync();
            return new OkResult();
        }

        public AppDb Db { get; }
    }
}