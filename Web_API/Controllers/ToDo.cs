using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDo : Controller
    {
        private static List<string> ToDos = new List<string>
        {
            ".Net Öğren",
            "Web APİ Öğren",
            "Uygulama Geliştir"
        };

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(ToDos);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id) 
        {
            if (id < 0 || id >= ToDos.Count)
            
                return NotFound();
                return Ok(ToDos[id]);          
        }

        [HttpPost]
        public ActionResult Post([FromBody] string data) 
        {
            ToDos.Add(data);
            return CreatedAtAction(nameof(Get),new { id = ToDos.Count - 1 }, data);
        }

        [HttpPut("{id}")]
        public ActionResult Put (int id, [FromBody] string data)
        {
            if (id < 0 || id >= ToDos.Count)
                return NotFound();

            ToDos[id] = data;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) 
        {
            if (id < 0 || id >= ToDos.Count)
                return NotFound();

            ToDos.RemoveAt(id);
            return NoContent();
        }

    }
}
