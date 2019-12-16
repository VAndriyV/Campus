using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd();

            builder.HasIndex(u => u.Email)
                .IsUnique();
            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.PasswordHash)
                .HasMaxLength(255);           

            builder.Property(u => u.LastVisit)
                .HasColumnType("datetime");        
                
        }
    }
}
