using DocumentAccessApproval.Application.Abstractions;
using DocumentAccessApproval.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DocumentAccessApproval.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<AccessRequest> AccessRequests => Set<AccessRequest>();
        public DbSet<Decision> Decisions => Set<Decision>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
