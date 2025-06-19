using DocumentAccessApproval.Domain.Entities;

namespace DocumentAccessApproval.Application.Abstractions
{
    public interface INotificationService
    {
        Task SendNotificationAsync(AccessRequest accessRequest);
    }
}