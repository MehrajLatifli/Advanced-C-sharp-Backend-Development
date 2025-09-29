using HumanWebAPI.FakeRepos;
using HumanWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace HumanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(FakeRepos.FakeRepos.Humans);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var human = FakeRepos.FakeRepos.Humans.FirstOrDefault(p => p.Id == id);
            if (human == null) return NotFound();
            return Ok(human);
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateHumanDTO   createHumanDTO)
        {

           var human =  new Human { Id = FakeRepos.FakeRepos.Humans.Count + 1, Name = createHumanDTO.Name, Age = createHumanDTO.Age };
     

            FakeRepos.FakeRepos.Humans.Add(human);

            return CreatedAtAction(nameof(GetById), new { id = human.Id }, human);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateHumanDTO  updateHumanDTO)
        {
            var human = FakeRepos.FakeRepos.Humans.FirstOrDefault(p => p.Id == id);
            if (human == null) return NotFound();

            human.Id = id;
            human.Name = updateHumanDTO.Name;
            human.Age = updateHumanDTO.Age;
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var human = FakeRepos.FakeRepos.Humans.FirstOrDefault(p => p.Id == id);
            if (human == null)
                return NoContent(); 

            FakeRepos.FakeRepos.Humans.Remove(human);
            return NoContent();
        }
    }

}
