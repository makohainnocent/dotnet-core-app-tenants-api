using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ApartmentsFeatures.Queries
{
    public class GetApartmentsByIdQuery : IRequest<Apartments>
    {
        public int apartmentId { get; set; }
        public class GetApartmentsByIdQueryHandler : IRequestHandler<GetApartmentsByIdQuery, Apartments>
        {
            private readonly IApplicationDbContext _context;
            public GetApartmentsByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Apartments> Handle(GetApartmentsByIdQuery query, CancellationToken cancellationToken)
            {
                var Apartments = _context.Apartments.Where(a => a.apartmentId == query.apartmentId).FirstOrDefault();
                if (Apartments == null) return null;
                return Apartments;
            }
        }
    }
}

