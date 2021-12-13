using Application;
//using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PayementsFeatures.Queries
{
    public class GetAllPayementsQuery : IRequest<IEnumerable<Payements>>
    {

        public class GetAllPayementsQueryHandler : IRequestHandler<GetAllPayementsQuery, IEnumerable<Payements>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPayementsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Payements>> Handle(GetAllPayementsQuery query, CancellationToken cancellationToken)
            {
                var PayementsList = await _context.Payements.ToListAsync();
                if (PayementsList == null)
                {
                    return null;
                }
                return PayementsList.AsReadOnly();
            }
        }
    }
}