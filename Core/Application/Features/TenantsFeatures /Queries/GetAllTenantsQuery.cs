using Application;
//using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TenantsFeatures.Queries
{
    public class GetAllTenantsQuery : IRequest<IEnumerable<Tenants>>
    {

        public class GetAllTenantsQueryHandler : IRequestHandler<GetAllTenantsQuery, IEnumerable<Tenants>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllTenantsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Tenants>> Handle(GetAllTenantsQuery query, CancellationToken cancellationToken)
            {
                var TenantsList = await _context.Tenants.ToListAsync();
                if (TenantsList == null)
                {
                    return null;
                }
                return TenantsList.AsReadOnly();
            }
        }
    }
}