using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PayementsFeatures.Commands
{
    public class UpdatePayementsCommand : IRequest<int>
    {
        public int payementId { get; set; }
        public int Paid { get; set; }
        public int roomId { get; set; }
        public class UpdatePayementsCommandHandler : IRequestHandler<UpdatePayementsCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdatePayementsCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdatePayementsCommand command, CancellationToken cancellationToken)
            {
                var Payements = _context.Payements.Where(a => a.payementId == command.payementId).FirstOrDefault();

                if (Payements == null)
                {
                    return default;
                }
                else
                {
                    Payements.Paid = command.Paid;
                    Payements.roomId = command.roomId;
                    await _context.SaveChanges();
                    return Payements.payementId;
                }
            }
        }
    }
}