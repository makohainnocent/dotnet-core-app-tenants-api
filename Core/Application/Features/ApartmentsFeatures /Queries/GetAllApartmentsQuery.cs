using Application;
//using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ApartmentsFeatures.Queries
{
    public class GetAllApartmentsQuery : IRequest<IEnumerable<Apartments>>
    {

        public class GetAllApartmentsQueryHandler : IRequestHandler<GetAllApartmentsQuery, IEnumerable<Apartments>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllApartmentsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Apartments>> Handle(GetAllApartmentsQuery query, CancellationToken cancellationToken)
            {
                var ApartmentsList = await _context.Apartments.ToListAsync();
                if (ApartmentsList == null)
                {
                    return null;
                }
                return ApartmentsList.AsReadOnly();
            }
        }
    }
}