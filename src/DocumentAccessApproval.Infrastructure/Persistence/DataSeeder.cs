using DocumentAccessApproval.Domain.Entities;
using DocumentAccessApproval.Domain.Enums;

namespace DocumentAccessApproval.Infrastructure.Persistence
{
    public static class DataSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Users.Any())
                return;

            // --- Seed Users ---
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = "user@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("pass"),
                Role = Role.User
            };

            var approver = new User
            {
                Id = Guid.NewGuid(),
                Email = "approver@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("pass"),
                Role = Role.Approver
            };

            context.Users.AddRange(user, approver);

            // --- Seed Documents ---
            var doc1 = new Document { Id = Guid.NewGuid(), Name = "Document 1" };
            var doc2 = new Document { Id = Guid.NewGuid(), Name = "Document 2" };
            var doc3 = new Document { Id = Guid.NewGuid(), Name = "Document 3" };

            context.Documents.AddRange(doc1, doc2, doc3);

            context.SaveChanges();
        }
    }
}
