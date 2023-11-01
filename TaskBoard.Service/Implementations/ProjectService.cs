using TaskBoard.Service.Interfaces;
using TaskBoard.Service.DTO;
using TaskBoard.DAL.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Service.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<IEnumerable<ProjectEntity>> GetAsync()
        {
            var projects = projectRepository.GetAll();

            return projects;
        }

        public async Task<bool> CreateAsync(ProjectDTO projectModel)
        {
            var project = new ProjectEntity()
            {
                Name = projectModel.Name,
                Description = projectModel.Description
            };

            await projectRepository.Create(project);

            return true;
        }

        public async Task<bool> UpdateAsync(ProjectDTO projectModel)
        {
            var projectObj = new ProjectEntity()
            {
                Id = projectModel.Id
            };

            var project = await projectRepository.GetByIdProject(projectObj.Id);

            project.Name = projectModel.Name;
            project.Description = projectModel.Description;

            await projectRepository.Update(project);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await projectRepository.GetByIdProject(id);

            if (project == null)
                return false;

            await projectRepository.Delete(project);

            return true;
        }
    }
}
