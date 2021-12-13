using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TenantsFeatures.Commands
{
    public class UpdateTenantsCommand : IRequest<int>
    {
        public int tenantId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public int roomId { get; set; }
        public class UpdateTenantsCommandHandler : IRequestHandler<UpdateTenantsCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateTenantsCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateTenantsCommand command, CancellationToken cancellationToken)
            {
                var Tenants = _context.Tenants.Where(a => a.tenantId == command.tenantId).FirstOrDefault();

                if (Tenants == null)
                {
                    return default;
                }
                else
                {
                    Tenants.firstName = command.firstName;
                    Tenants.lastName = command.lastName;
                    Tenants.phone = command.phone;
                    Tenants.roomId = command.roomId;
                    await _context.SaveChanges();
                    return Tenants.tenantId;
                }
            }
        }
    }
}