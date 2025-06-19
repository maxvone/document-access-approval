using System.ComponentModel.DataAnnotations;

namespace DocumentAccessApproval.Api.Dtos
{
    public record LoginRequest([Required] string Email, [Required] string Password);
}
