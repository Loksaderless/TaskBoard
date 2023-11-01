namespace TaskBoard.Domain.Models
{
    public class SprintEntity
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public ProjectEntity Project { get; set; }

        public DateTime StartSprint { get; set; }

        public DateTime EndSprint { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string? Comment { get; set; }

        public string? Files { get; set; }

        public List<User>? Users { get; set; }
    }
}
