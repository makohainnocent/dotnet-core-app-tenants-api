using Application;
//using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TenantsFeatures.Commands
{
    public class DeleteTenantsByIdCommand : IRequest<int>
    {
        public int tenantId { get; set; }
        public class DeleteTenantsByIdCommandHandler : IRequestHandler<DeleteTenantsByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteTenantsByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteTenantsByIdCommand command, CancellationToken cancellationToken)
            {
                var Tenants = await _context.Tenants.Where(a => a.tenantId == command.tenantId).FirstOrDefaultAsync();
                if (Tenants == null) return default;
                _context.Tenants.Remove(Tenants);
                await _context.SaveChanges();
                return Tenants.tenantId;
            }
        }
    }
}