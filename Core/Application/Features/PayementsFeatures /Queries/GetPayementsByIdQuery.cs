using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PayementsFeatures.Queries
{
    public class GetPayementsByIdQuery : IRequest<Payements>
    {
        public int payementId { get; set; }
        public class GetPayementsByIdQueryHandler : IRequestHandler<GetPayementsByIdQuery, Payements>
        {
            private readonly IApplicationDbContext _context;
            public GetPayementsByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Payements> Handle(GetPayementsByIdQuery query, CancellationToken cancellationToken)
            {
                var Payements = _context.Payements.Where(a => a.payementId == query.payementId).FirstOrDefault();
                if (Payements == null) return null;
                return Payements;
            }
        }
    }
}

