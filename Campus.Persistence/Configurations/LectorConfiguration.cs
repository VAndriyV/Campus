using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Campus.Domain.Entities;

namespace Campus.Persistence.Configurations
{
    public class LectorConfiguration : IEntityTypeConfiguration<Lector>
    {
        public void Configure(EntityTypeBuilder<Lector> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.Id)
                .ValueGeneratedOnAdd();

            builder.Property(l => l.FirstName)
                .IsRequired()
                .HasMaxLength(35);

            builder.Property(l => l.LastName)
               .IsRequired()
               .HasMaxLength(35);

            builder.Property(l => l.Patronymic)
               .IsRequired()
               .HasMaxLength(35);

            builder.Property(l => l.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(l => l.PhoneNumber)
               .IsRequired()
               .HasMaxLength(24);            

            builder.HasOne(l => l.AcademicDegree)
                .WithMany(ad => ad.Lectors)
                .HasForeignKey(l => l.AcademicDegreeId)
                .IsRequired();

            builder.HasOne(l => l.AcademicRank)
               .WithMany(ar => ar.Lectors)
               .HasForeignKey(l => l.AcademicRankId)
               .IsRequired();

            builder.HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .IsRequired();
        }
    }
}
