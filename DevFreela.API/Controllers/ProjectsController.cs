using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options; 

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectServices  _projectServices;
        public ProjectsController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
        }

        // api/projects?query=599
        [HttpGet]
        public IActionResult Get(string query)
        {
           var projects =  _projectServices.GetAll(query);

            return Ok(projects);
        }
         

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if(inputModel.Title.Length > 8)
            {
                return BadRequest();
            }

            var id = _projectServices.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel); ;            
        }

        // api/projects/599  
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _projectServices.GetById(id);
                     
            return Ok(project);
        }

        // api/projects/2
        // Pelo corpo da requisição
        [HttpPut]
        public IActionResult Put (int id, [FromBody] UpdateProjectInputModel inputModel)
        {
            if(inputModel.Description.Length > 200)
            {
                return BadRequest();
            } 
            _projectServices.Update(inputModel);

            return NoContent();
        }

        //api/project/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            _projectServices.Delete(id);

            return NoContent();
        }


        //api/project/1/comments /POST
        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel)
        {

            _projectServices.CreateComment(inputModel);

            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectServices.Start(id);

            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult finish(int id)
        {
            _projectServices.Finish(id);

            return NoContent();
        }
    }
}
