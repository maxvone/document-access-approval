using DocumentAccessApproval.Application.Features.Documents.Queries.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentAccessApproval.Application.Features.Documents.Queries.GetAllDocuments
{
    public record GetAllDocumentsQuery() : IRequest<IEnumerable<DocumentDto>>;
}
