using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        public UsersController(ExempleClass exempleClass) 
        {
        }
        [HttpGet("{id}")]
        public  IActionResult GetById (int id)
        {
            return Ok(new { id });
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateUserModel createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1}, createUserModel);
        }

        // api/Users/1/login
        [HttpPut("{id}/login")]
        public IActionResult login(int id, [FromBody] LoginModel loginModel)
        {
            return NoContent();
        }
    }
}
