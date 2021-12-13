using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PayementsFeatures.Commands
{
    public class CreatePayementsCommand : IRequest<int>
    {
        public int payementId { get; set; }
        public int Paid { get; set; }
        public int roomId { get; set; }
        public class CreatePayementsCommandHandler : IRequestHandler<CreatePayementsCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreatePayementsCommandHandler(IApplicationDbContext context)
            {
                this._context = context;
            }
            public async Task<int> Handle(CreatePayementsCommand command, CancellationToken cancellationToken)
            {
                var Payements = new Payements();
                Payements.Paid = command.Paid;
                Payements.roomId = command.roomId;
                _context.Payements.Add(Payements);
                await _context.SaveChanges();
                return Payements.payementId;
            }
        }
    }
}



