namespace DocumentAccessApproval.Application.Features.AccessRequest.Queries.Dtos
{
    // DTO for a user checking their own requests
    public class AccessRequestDto
    {
        public Guid Id { get; set; }
        public string DocumentName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime RequestDate { get; set; }
        public string? DecisionComment { get; set; }
    }
}
