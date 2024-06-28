using Microsoft.EntityFrameworkCore;

namespace OrchestratorServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Workflow> Workflows { get; set; }
        public DbSet<Node> Nodes { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<TagElement> Tags { get; set; }
        public DbSet<PackageData> PackageDatas { get; set; }
    }
}
