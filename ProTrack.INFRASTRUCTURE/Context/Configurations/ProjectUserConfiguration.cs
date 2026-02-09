using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProTrack.DOMAIN.Entities;

namespace ProTrack.INFRAESTRUCTURE.Context.Configurations;

public class ProjectUserConfiguration : IEntityTypeConfiguration<ProjectUser>
{
    public void Configure(EntityTypeBuilder<ProjectUser> builder)
    {
        builder.HasKey(pu => new { pu.ProjectId, pu.UserId });

        builder.Property(pu => pu.Role)
            .HasMaxLength(50)
            .HasDefaultValue("Member");

        builder.HasOne(pu => pu.User)
            .WithMany(u => u.ProjectUsers)
            .HasForeignKey(pu => pu.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder.HasOne(pu => pu.Project)
            .WithMany(p => p.ProjectUsers)
            .HasForeignKey(pu => pu.ProjectId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}
