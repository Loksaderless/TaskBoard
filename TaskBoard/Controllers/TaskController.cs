using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Service.DTO;
using TaskBoard.Service.Interfaces;

namespace TaskBoard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService taskService;
        private readonly IWebHostEnvironment env;

        public TaskController(ITaskService taskService, IWebHostEnvironment env)
        {
            this.taskService = taskService;
            this.env = env;
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("tasks")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await taskService.GetAsync();

            return Ok(tasks);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("tasks")]
        public async Task<IActionResult> CreateTask(TaskDTO model)
        {
            if (model == null)
                return BadRequest();

            var taskModel = new TaskDTO()
            {
                SprintId = model.SprintId,
                Name = model.Name,
                Description = model.Description,
                Comment = model.Comment
            };

            await taskService.CreateAsync(taskModel);

            return Ok(new { Message = "Added Success" });
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPut("tasks")]
        public async Task<IActionResult> UpdateTask(TaskDTO model)
        {
            if (model == null)
                return BadRequest();

            var taskModel = new TaskDTO()
            {
                Id = model.Id,
                SprintId = model.SprintId,
                Name = model.Name,
                Description = model.Description,
                Comment = model.Comment
            };

            await taskService.UpdateAsync(taskModel);

            return Ok(new { Message = "Update Success" });
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpDelete("tasks/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var result = await taskService.DeleteAsync(id);

            if (result == true)
                return Ok(new { Message = "Delete Success" });
            else
                return NotFound(new { Message = "Task not Found" });
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("tasks/getAllSprintId")]
        public async Task<IActionResult> GetAllSprintId()
        {
            var result = await taskService.GetAllSprintIdAsync();

            return Ok(result);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpGet("tasks/getAllUsersLogin")]
        public async Task<IActionResult> GetAllUsersLogin()
        {
            var result = await taskService.GetAllUsersLoginAsync();

            return Ok(result);
        }

        [Authorize(Roles = "Admin, Manager")]
        [HttpPost("tasks/saveFile")]
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

                return NotFound(new { Message = $"File Save: {ex}" });
            }
        }
    }
}
