using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProTrack.DOMAIN.Entities;

namespace ProTrack.INFRAESTRUCTURE.Context.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Content)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasQueryFilter(c => !c.IsDeleted);

        builder.HasOne(c => c.Task)
            .WithMany()
            .HasForeignKey(c => c.TaskId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(c => c.User)
            .WithMany()
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
