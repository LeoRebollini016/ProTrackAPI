using Microsoft.EntityFrameworkCore;
using ProTrack.DOMAIN.Entities;
using TaskStatus = ProTrack.DOMAIN.Entities.TaskStatus;

namespace ProTrack.INFRAESTRUCTURE.Context.Configurations;

public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ProjectTask> builder)
    {
        builder.ToTable("tasks");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(t => t.Description)
            .HasMaxLength(500);
        builder.Property(t => t.Status)
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasDefaultValue(TaskStatus.ToDo);
        builder.Property(t => t.Priority)
            .HasConversion<string>()
            .HasMaxLength(20)
            .HasSentinel(TaskPriority.None)
            .HasDefaultValue(TaskPriority.Medium);

        builder.HasQueryFilter(t => !t.IsDeleted);

        builder.HasOne(t => t.AssignedToUser)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey( t => t.AssignedToUserId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);
    }
}