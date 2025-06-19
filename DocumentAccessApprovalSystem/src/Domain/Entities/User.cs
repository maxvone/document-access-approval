
using System.ComponentModel.DataAnnotations;
using DocumentAccessApprovalSystem.Domain.Enums;

namespace DocumentAccessApprovalSystem.Domain.Entities
{
	public class User
	{
		[Key]
		[Required]
		public Guid Id { get; set; }

		[EmailAddress]
		[Required]
		public string Email { get; set; }

		[Required]
		public string PasswordHash { get; set; }

		[Required]
		public Role Role { get; set; }
	}
}