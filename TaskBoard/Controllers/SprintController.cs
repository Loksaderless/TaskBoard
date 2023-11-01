using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Service.DTO;
using TaskBoard.Service.Interfaces;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SprintController : ControllerBase
    {
        private readonly ISprintService sprintService;
        private readonly IWebHostEnvironment env;

        public SprintController(ISprintService sprintService, IWebHostEnvironment env)
        {
            this.sprintService = sprintService;
            this.env = env;
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("sprints")]
        public async Task<IActionResult> GetSprints()
        {
            var sprints = await sprintService.GetAsync();

            return Ok(sprints);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("sprints")]
        public async Task<IActionResult> CreateSprint(SprintDTO model)
        {
            if (model == null)
                return BadRequest();

            var sprintModel = new SprintDTO()
            {
                ProjectId = model.ProjectId,
                StartSprint = model.StartSprint,
                EndSprint = model.EndSprint,
                Name = model.Name,
                Description = model.Description,
                Comment = model.Comment,
                Users = model.Users
            };

            await sprintService.CreateAsync(sprintModel);

            return Ok(new { Message = "Added Success" });
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("sprints")]
        public async Task<IActionResult> UpdateSprint(SprintDTO model)
        {
            if (model == null)
                return BadRequest();

            var sprintModel = new SprintDTO()
            {
                Id = model.Id,
                ProjectId = model.ProjectId,
                StartSprint = model.StartSprint,
                EndSprint = model.EndSprint,
                Name = model.Name,
                Description = model.Description,
                Comment = model.Comment,
                Users = model.Users
            };

            await sprintService.UpdateAsync(sprintModel);

            return Ok(new { Message = "Update Success" });
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete("sprints/{id}")]
        public async Task<IActionResult> DeleteSprint(int id)
        {
            var result = await sprintService.DeleteAsync(id);

            if (result == true)
                return Ok(new { Message = "Delete Success" });
            else
                return NotFound(new { Message = "Sprint not Found" });
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("sprints/getAllProjectId")]
        public async Task<IActionResult> GetAllProjectId()
        {
            var result = await sprintService.GetAllProjectIdAsync();

            return Ok(result);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("sprints/getAllUsersLogin")]
        public async Task<IActionResult> GetAllUsersLogin()
        {
            var result = await sprintService.GetAllUsersLoginAsync();

            return Ok(result);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("sprints/saveFile")]
        public IActionResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = env.ContentRootPath + "/Files/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return Ok(new { Message = "File Save Success" });
            }
            catch (Exception ex)
            {

                return NotFound(new { Message = $"File Save: {ex}"});
            }
        }
    }
}
