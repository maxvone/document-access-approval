
using System.ComponentModel.DataAnnotations;
using DocumentAccessApproval.Domain.Enums;

namespace DocumentAccessApproval.Domain.Entities
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