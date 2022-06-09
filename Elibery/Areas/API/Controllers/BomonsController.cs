using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elibery.Areas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BomonsController : ControllerBase
    {
        // GET: api/<BomonsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<BomonsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BomonsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BomonsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BomonsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
