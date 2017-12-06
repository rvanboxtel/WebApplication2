using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WebApplication2.Dao;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class MainController : ApiController
    {
        // Set here the connection string to the Postgres database
        public const string DatabaseConnectionString = "host=localhost;port=5432;username=test;password=test;database=windesheim;Timeout=60;";

        // Create a new db context (db connection)
        private readonly DbContext _context = new DbContext(DatabaseConnectionString);

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<main>> Get()
        {
            return await new Query<main>(_context).List();
        }

        // GET api/values/5
        [HttpGet]
        public async Task<main> Get(int id)
        {
            return await new Query<main>(_context).Read(id);
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody]main value)
        {
            await new Query<main>(_context).Create(value);
        }

        // PUT api/values/5
        [HttpPut]
        public async Task Put([FromBody]main value)
        {
            await new Query<main>(_context).Update(value);
        }

        // DELETE api/values/5
        [HttpDelete]
        public async Task Delete(int id)
        {
            var item = await new Query<main>(_context).Read(id);
            await new Query<main>(_context).Delete(item);
        }
    }