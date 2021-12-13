using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TenantsFeatures.Queries
{
    public class GetTenantsByIdQuery : IRequest<Tenants>
    {
        public int tenantId { get; set; }
        public class GetTenantsByIdQueryHandler : IRequestHandler<GetTenantsByIdQuery, Tenants>
        {
            private readonly IApplicationDbContext _context;
            public GetTenantsByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Tenants> Handle(GetTenantsByIdQuery query, CancellationToken cancellationToken)
            {
                var Tenants = _context.Tenants.Where(a => a.tenantId == query.tenantId).FirstOrDefault();
                if (Tenants == null) return null;
                return Tenants;
            }
        }
    }
}

