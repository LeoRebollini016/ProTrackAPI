using ProTrack.DOMAIN.Common;
using ProTrack.DOMAIN.Enum;
using static ProTrack.DOMAIN.Constants.Constants.AppConstants.DomainConstants;

namespace ProTrack.DOMAIN.Entities;

public class Project : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ProjectStatusEnum Status { get; set; } = ProjectStatusEnum.Active;
    public DateTime? TargetDate { get; set; }
    public bool IsCompleted => Status == ProjectStatusEnum.Completed;
    public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();
    public virtual ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();

    public string? UpdateMemberRole(Guid requestorId, Guid userId, ProjectUserRoleEnum newRole)
    {
        var requestor = ProjectUsers.FirstOrDefault(pu => pu.UserId == requestorId && !pu.IsDeleted);
        if (requestor == null)
            return EntityNotFound;

        var member = ProjectUsers.FirstOrDefault(pu => pu.UserId == userId && !pu.IsDeleted);
        if (member == null)
            return EntityNotFound;
        
        if (Status == ProjectStatusEnum.Completed)
            return CompletedProject;

        member.Role = newRole;
        return null;
    }
}