using System.ComponentModel.DataAnnotations;
using DocumentAccessApproval.Domain.Enums;

namespace DocumentAccessApproval.Domain.Entities
{
    public class AccessRequest
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid RequestorId { get; set; }

        [Required]
        public Guid DocumentId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Reason { get; set; } = string.Empty;
        public AccessType RequestedAccessType { get; set; }
        public AccessRequestStatus Status { get; set; }
        public DateTime RequestDate { get; set; }

        // This will be null until a decision is made.
        public Guid? DecisionId { get; set; }

        // Navigation properties
        public virtual User? Requestor { get; set; }
        public virtual Document? Document { get; set; }
        public virtual Decision? Decision { get; set; }

        // Business Logic Method
        public void ProcessDecision(Decision decision)
        {
            if (Status != AccessRequestStatus.Pending)
                throw new InvalidOperationException("A decision has already been made for this request.");

            Decision = decision;
            DecisionId = decision.Id;
            Status = decision.IsApproved ? AccessRequestStatus.Approved : AccessRequestStatus.Rejected;
        }
    }
}