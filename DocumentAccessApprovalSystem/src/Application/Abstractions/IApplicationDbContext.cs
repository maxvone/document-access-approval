using DocumentAccessApprovalSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApprovalSystem.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; }
        DbSet<Document> Documents { get; }
        DbSet<AccessRequest> AccessRequests { get; }
        DbSet<Decision> Decisions { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}