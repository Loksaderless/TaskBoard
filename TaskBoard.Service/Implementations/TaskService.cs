using TaskBoard.DAL.Interfaces;
using TaskBoard.Domain.Models;
using TaskBoard.Domain.Enum;
using TaskBoard.Service.DTO;
using TaskBoard.Service.Interfaces;

namespace TaskBoard.Service.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public async Task<IEnumerable<TaskEntity>> GetAsync()
        {
            var tasks = taskRepository.GetAll();

            return tasks;
        }

        public async Task<bool> CreateAsync(TaskDTO taskModel)
        {
            var task = new TaskEntity()
            {
                SprintId = taskModel.SprintId,
                Name = taskModel.Name,
                Description = taskModel.Description,
                Comment = taskModel.Comment,
                StatusTask = StatusTask.Open
            };

            await taskRepository.Create(task);

            return true;
        }

        public async Task<bool> UpdateAsync(TaskDTO taskModel)
        {
            var taskObj = new TaskEntity()
            {
                Id = taskModel.Id
            };

            var task = await taskRepository.GetByIdTask(taskObj.Id);

            task.SprintId = taskModel.SprintId;
            task.Name = taskModel.Name;
            task.Description = taskModel.Description;
            task.Comment = taskModel.Comment;

            await taskRepository.Update(task);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await taskRepository.GetByIdTask(id);

            if (task == null)
                return false;

            await taskRepository.Delete(task);

            return true;
        }

        public async Task<IEnumerable<int>> GetAllSprintIdAsync()
        {
            return taskRepository.GetSprintId();
        }

        public async Task<IEnumerable<string>> GetAllUsersLoginAsync()
        {
            return taskRepository.GetUsersLogin();
        }
    }
}
