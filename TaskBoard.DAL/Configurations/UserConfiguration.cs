using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoard.Domain.Models;

namespace TaskBoard.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id).ValueGeneratedOnAdd();

            builder.Property(u => u.Login).HasMaxLength(50).IsRequired();

            builder.Property(u => u.Password).HasMaxLength(300).IsRequired();

            builder.Property(u => u.Codeword).HasMaxLength(300).IsRequired();
        }
    }
}
