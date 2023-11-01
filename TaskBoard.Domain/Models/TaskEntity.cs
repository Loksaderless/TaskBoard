using TaskBoard.Domain.Enum;

namespace TaskBoard.Domain.Models
{
    public class TaskEntity
    {
        public int Id { get; set; }

        public int SprintId { get; set; }

        public SprintEntity Sprint { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public StatusTask StatusTask { get; set; }

        public string? Comment { get; set; }

        public string? Files { get; set; }

        public List<User>? Users { get; set; }
    }
}
