using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elibery.Areas.API.Controllers
{
    [Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class CauhoisController : ControllerBase
    {
        // GET: api/<CauhoisController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CauhoisController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CauhoisController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CauhoisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CauhoisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
