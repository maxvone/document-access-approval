using DocumentAccessApproval.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DocumentAccessApproval.Api.Dtos
{
    public record CreateAccessRequestDto(
        [Required] Guid DocumentId,
        [Required] string Reason,
        [Required] AccessType AccessType);

    public record DecideRequestDto(
        [Required] bool IsApproved,
        [Required] string Comment);
}
