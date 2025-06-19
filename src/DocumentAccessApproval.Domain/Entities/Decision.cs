using System.ComponentModel.DataAnnotations;

namespace DocumentAccessApproval.Domain.Entities
{
	public class Decision
	{
		[Key]
		public Guid Id { get; set; }
		
		public Guid AccessRequestId { get; set; }
		public Guid ApproverId { get; set; }
		public bool IsApproved { get; set; }
		public string Comment { get; set; } = string.Empty;
		public DateTime DecisionDate { get; set; }

		// Navigation properties
		public virtual User? Approver { get; set; }
		public virtual AccessRequest? AccessRequest { get; set; }
	}
}