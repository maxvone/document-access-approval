using DocumentAccessApproval.Application.Abstractions;
using DocumentAccessApproval.Application.Features.Documents.Queries.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DocumentAccessApproval.Application.Features.Documents.Queries.GetAllDocuments
{
    public class GetAllDocumentsQueryHandler : IRequestHandler<GetAllDocumentsQuery, IEnumerable<DocumentDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllDocumentsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentDto>> Handle(GetAllDocumentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Documents
                .AsNoTracking()
                .Select(d => new DocumentDto
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync(cancellationToken);
        }
    }
}
