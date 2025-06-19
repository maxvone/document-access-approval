using DocumentAccessApproval.Application.Abstractions;
using DocumentAccessApproval.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentAccessApproval.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;

        public NotificationService(ILogger<NotificationService> logger)
        {
            _logger = logger;
        }

        public Task SendNotificationAsync(AccessRequest request)
        {
            // Simulate sending a notification
            _logger.LogInformation(
                "--- SIMULATING NOTIFICATION --- \n" +
                "To: {RequestorEmail}\n" +
                "Subject: Your access request for document {DocumentId} has been {Status}.\n" +
                "Decision Comment: {Comment}",
                request.Requestor?.Email ?? "N/A", // Email would need to be loaded for this to work
                request.DocumentId,
                request.Status,
                request.Decision?.Comment ?? "N/A");

            return Task.CompletedTask;
        }
    }
}
