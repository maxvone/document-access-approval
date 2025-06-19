using System.ComponentModel.DataAnnotations;

namespace DocumentAccessApprovalSystem.Domain.Entities
{
	public class Document
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}