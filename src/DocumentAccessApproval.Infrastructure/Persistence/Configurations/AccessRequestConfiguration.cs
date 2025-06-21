using DocumentAccessApproval.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DocumentAccessApproval.Infrastructure.Persistence.Configurations
{
    public class AccessRequestConfiguration : IEntityTypeConfiguration<AccessRequest>
    {
        public void Configure(EntityTypeBuilder<AccessRequest> builder)
        {
            // Configure the one-to-one relationship between AccessRequest and Decision
            // An AccessRequest has one Decision, and the Decision has one AccessRequest.
            // The foreign key ('AccessRequestId') is in the Decision table.
            // This makes Decision the dependent entity.
            builder.HasOne(ar => ar.Decision)
                   .WithOne(d => d.AccessRequest)
                   .HasForeignKey<Decision>(d => d.AccessRequestId);

            // Configure the relationship with the Requestor (User)
            builder.HasOne(ar => ar.Requestor)
                   .WithMany() // A user can have many requests
                   .HasForeignKey(ar => ar.RequestorId)
                   .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a user if they have requests

            // Configure the relationship with the Document
            builder.HasOne(ar => ar.Document)
                    .WithMany() // A document can be part of many requests
                    .HasForeignKey(ar => ar.DocumentId)
                    .OnDelete(DeleteBehavior.Restrict); // Prevent deleting a document if it's in a request
        }
    }
}
