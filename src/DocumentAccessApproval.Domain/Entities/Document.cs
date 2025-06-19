using System.ComponentModel.DataAnnotations;

namespace DocumentAccessApproval.Domain.Entities
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