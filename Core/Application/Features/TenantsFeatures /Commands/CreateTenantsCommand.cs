using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.TenantsFeatures.Commands
{
    public class CreateTenantsCommand : IRequest<int>
    {
        public int tenantId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phone { get; set; }
        public int roomId { get; set; }
        public class CreateTenantsCommandHandler : IRequestHandler<CreateTenantsCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateTenantsCommandHandler(IApplicationDbContext context)
            {
                this._context = context;
            }
            public async Task<int> Handle(CreateTenantsCommand command, CancellationToken cancellationToken)
            {
                var Tenants = new Tenants();
                Tenants.firstName = command.firstName;
                Tenants.lastName = command.lastName;
                Tenants.phone=command.phone;
                Tenants.roomId=command.roomId;
                _context.Tenants.Add(Tenants);
                await _context.SaveChanges();
                return Tenants.tenantId;
            }
        }
    }
}



