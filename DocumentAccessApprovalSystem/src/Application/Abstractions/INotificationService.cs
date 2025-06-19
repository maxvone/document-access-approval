using DocumentAccessApprovalSystem.Domain.Entities;

namespace DocumentAccessApprovalSystem.Application.Abstractions
{
    public interface INotificationService
    {
        Task SendNotificationAsync(AccessRequest accessRequest);
    }
}