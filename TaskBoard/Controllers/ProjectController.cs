using Microsoft.AspNetCore.Mvc;
using TaskBoard.Service.Interfaces;
using TaskBoard.Service.DTO;
using Microsoft.AspNetCore.Authorization;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("projects")]
        public async Task<IActionResult> GetProjects()
        {
            var projects = await projectService.GetAsync();

            return Ok(projects);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("projects")]
        public async Task<IActionResult> CreateProject(ProjectDTO model)
        {
            if (model == null)
                return BadRequest();

            var projectModel = new ProjectDTO()
            {
                Name = model.Name,
                Description = model.Description
            };

            await projectService.CreateAsync(projectModel);

            return Ok(new { Message = "Added Success" });
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("projects")]
        public async Task<IActionResult> UpdateProject(ProjectDTO model)
        {
            if (model == null)
                return BadRequest();

            var projectModel = new ProjectDTO()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };

            await projectService.UpdateAsync(projectModel);

            return Ok(new { Message = "Update Success" });
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete("projects/{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            var result = await projectService.DeleteAsync(id);
            
            if (result == true)
                return Ok(new { Message = "Delete Success" });
            else
                return NotFound(new { Message = "Project not Found" });
        }
    }
}
