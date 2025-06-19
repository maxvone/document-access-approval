using DocumentAccessApproval.Domain.Entities;

namespace DocumentAccessApproval.Application.Abstractions
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}