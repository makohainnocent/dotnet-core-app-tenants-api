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

namespace Application.Features.ApartmentsFeatures.Commands
{
    public class DeleteApartmentsByIdCommand : IRequest<int>
    {
        public int apartmentId { get; set; }
        public class DeleteApartmentsByIdCommandHandler : IRequestHandler<DeleteApartmentsByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteApartmentsByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteApartmentsByIdCommand command, CancellationToken cancellationToken)
            {
                var Apartments = await _context.Apartments.Where(a => a.apartmentId == command.apartmentId).FirstOrDefaultAsync();
                if (Apartments == null) return default;
                _context.Apartments.Remove(Apartments);
                await _context.SaveChanges();
                return Apartments.apartmentId;
            }
        }
    }
}