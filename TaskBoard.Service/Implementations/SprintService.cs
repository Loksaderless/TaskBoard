using TaskBoard.DAL.Interfaces;
using TaskBoard.Domain.Models;
using TaskBoard.Service.DTO;
using TaskBoard.Service.Interfaces;

namespace TaskBoard.Service.Implementations
{
    public class SprintService : ISprintService
    {
        private readonly ISprintRepository sprintRepository;

        public SprintService(ISprintRepository sprintRepository)
        {
            this.sprintRepository = sprintRepository;
        }

        public async Task<IEnumerable<SprintEntity>> GetAsync()
        {
            var sprints = sprintRepository.GetAll();

            return sprints;
        }

        public async Task<bool> CreateAsync(SprintDTO sprintModel)
        {
            var sprint = new SprintEntity()
            {
                ProjectId = sprintModel.ProjectId,
                StartSprint = sprintModel.StartSprint,
                EndSprint = sprintModel.EndSprint,
                Name = sprintModel.Name,
                Description = sprintModel.Description,
                Comment = sprintModel.Comment
            };

            await sprintRepository.Create(sprint);

            return true;
        }

        public async Task<bool> UpdateAsync(SprintDTO sprintModel)
        {
            var sprintObj = new SprintEntity()
            {
                Id = sprintModel.Id
            };

            var sprint = await sprintRepository.GetByIdSprint(sprintObj.Id);

            sprint.ProjectId = sprintModel.ProjectId;
            sprint.StartSprint = sprintModel.StartSprint;
            sprint.EndSprint = sprintModel.EndSprint;
            sprint.Name = sprintModel.Name;
            sprint.Description = sprintModel.Description;
            sprint.Comment = sprintModel.Comment;

            await sprintRepository.Update(sprint);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sprint = await sprintRepository.GetByIdSprint(id);

            if (sprint == null)
                return false;

            await sprintRepository.Delete(sprint);

            return true;
        }

        public async Task<IEnumerable<int>> GetAllProjectIdAsync()
        {
            return sprintRepository.GetProjectId();
        }

        public async Task<IEnumerable<string>> GetAllUsersLoginAsync()
        {
            return sprintRepository.GetUsersLogin();
        }
    }
}
