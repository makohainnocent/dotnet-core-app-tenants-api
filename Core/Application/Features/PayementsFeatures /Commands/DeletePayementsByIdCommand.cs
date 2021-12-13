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

namespace Application.Features.PayementsFeatures.Commands
{
    public class DeletePayementsByIdCommand : IRequest<int>
    {
        public int payementId { get; set; }
        public class DeletePayementsByIdCommandHandler : IRequestHandler<DeletePayementsByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeletePayementsByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeletePayementsByIdCommand command, CancellationToken cancellationToken)
            {
                var Payements = await _context.Payements.Where(a => a.payementId == command.payementId).FirstOrDefaultAsync();
                if (Payements == null) return default;
                _context.Payements.Remove(Payements);
                await _context.SaveChanges();
                return Payements.payementId;
            }
        }
    }
}