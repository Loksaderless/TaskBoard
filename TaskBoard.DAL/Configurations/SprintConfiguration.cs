using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Models;

namespace TaskBoard.DAL.Configurations
{
    public class SprintConfiguration : IEntityTypeConfiguration<SprintEntity>
    {
        public void Configure(EntityTypeBuilder<SprintEntity> builder)
        {
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.Name).HasMaxLength(100).IsRequired();
        }
    }
}
