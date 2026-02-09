using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProTrack.DOMAIN.Entities;
using ProTrack.DOMAIN.Options;
using ProTrack.INFRAESTRUCTURE.Extensions;

namespace ProTrack.INFRAESTRUCTURE.Context;

public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>
{
    private readonly DatabaseOptions _databaseSettings;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IOptions<DatabaseOptions> databaseSettings) : base(options) 
    {
        _databaseSettings = databaseSettings.Value;
    }

    public DbSet<Project> Projects => Set<Project>();
    public DbSet<ProjectTask> Tasks => Set<ProjectTask>();
    public DbSet<ProjectUser> ProjectUsers => Set<ProjectUser>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureIdentityTableNames();
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_databaseSettings.DefaultConnection)
            .UseSnakeCaseNamingConvention();
        base.OnConfiguring(optionsBuilder);
    }
}