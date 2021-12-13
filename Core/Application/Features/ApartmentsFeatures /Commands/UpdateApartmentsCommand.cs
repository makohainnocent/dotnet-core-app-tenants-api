using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ApartmentsFeatures.Commands
{
    public class UpdateApartmentsCommand : IRequest<int>
    {
        public int apartmentId { get; set; }
        public string Name { get; set; }
        public int  userId { get; set; }
        public class UpdateApartmentsCommandHandler : IRequestHandler<UpdateApartmentsCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateApartmentsCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateApartmentsCommand command, CancellationToken cancellationToken)
            {
                var Apartments = _context.Apartments.Where(a => a.apartmentId == command.apartmentId).FirstOrDefault();

                if (Apartments == null)
                {
                    return default;
                }
                else
                {
                    Apartments.Name = command.Name;
                    Apartments.userId = command.userId;
                    await _context.SaveChanges();
                    return Apartments.apartmentId;
                }
            }
        }
    }
}