namespace DocumentAccessApproval.Application.Features.AccessRequest.Queries.Dtos
{
    // DTO for an approver viewing pending requests
    public class PendingRequestDto
    {
        public Guid RequestId { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string RequestorEmail { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string RequestedAccessType { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }
    }
}
