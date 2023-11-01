using TaskBoard.Domain.Enum;

namespace TaskBoard.Domain.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Codeword { get; set; }

        public string Role { get; set; }

        public List<SprintEntity>? Sprints { get; set; }

        public List<TaskEntity>? Tasks { get; set; }
    }
}
