namespace TaskBoard.Service.DTO
{
    public class TaskDTO
    {
        public int Id { get; set; }

        public int SprintId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public string User { get; set; }
    }
}
