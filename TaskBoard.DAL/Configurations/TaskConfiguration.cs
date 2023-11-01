using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Models;

namespace TaskBoard.DAL.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
        }
    }
}
