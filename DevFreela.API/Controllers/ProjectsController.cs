using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {

        // api/projects?query=599
        [HttpGet]
        public IActionResult Get(string query)
        {
            // Buscar ou fitlrar
            return Ok();
        }


        // api/projects/599  
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //not Found
            //Buscar o projeto
            return Ok($"paramêtro recebido foi {id}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProjectModel)
        {
            if(createProjectModel.Title.Length > 8)
            {
                return BadRequest();
            }
            // Cadastrar o projeto
            return CreatedAtAction(nameof(GetById), new { id = createProjectModel.Id }, createProjectModel); ;            
        }

        // api/projects/2
        // Pelo corpo da requisição
        [HttpPut]
        public IActionResult Put (int id, [FromBody]UpdateProjectsModel updateProjects)
        {
            if(updateProjects.Description.Length > 8)
            {
                return BadRequest();
            }

            //atualizo o objeto
            return NoContent();
        }

        //api/project/3
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {

            //Obter projetos para se excluido caso não existar, retornar NotFound
            //Remover
            return NoContent();
        }
    }
}
