using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    { 
        [HttpGet("{id}")]
        public  IActionResult GetById (int id)
        {
            return Ok(new { id });
        }


        [HttpPost]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1}, inputModel);
        }

        //// api/users/1/login
        //[httpput("{id}/login")]
        //public iactionresult login(int id, [frombody] loginmodel inputmodel)
        //{
        //    return nocontent();
        //}
    }
}
