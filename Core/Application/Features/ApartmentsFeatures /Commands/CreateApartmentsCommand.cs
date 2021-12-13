using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ApartmentsFeatures.Commands
{
    public class CreateApartmentsCommand : IRequest<int>
    {
        public int apartmentId { get; set; }
        public string Name { get; set; }
        public int  userId { get; set; }
        public class CreateApartmentsCommandHandler : IRequestHandler<CreateApartmentsCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateApartmentsCommandHandler(IApplicationDbContext context)
            {
                this._context = context;
            }
            public async Task<int> Handle(CreateApartmentsCommand command, CancellationToken cancellationToken)
            {
                var Apartments = new Apartments();
                Apartments.Name = command.Name;
                Apartments.userId = command.userId;
                _context.Apartments.Add(Apartments);
                await _context.SaveChanges();
                return Apartments.apartmentId;
            }
        }
    }
}



