namespace TaskBoard.Service.DTO
{
    public class SprintDTO
    {
        public int Id { get; set; }

        public int ProjectId { get; set; }

        public DateTime StartSprint { get; set; }

        public DateTime EndSprint { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Comment { get; set; }

        public string Users { get; set; }
    }
}
