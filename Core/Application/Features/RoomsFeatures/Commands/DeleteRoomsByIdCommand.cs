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

namespace Application.Features.RoomsFeatures.Commands
{
    public class DeleteRoomsByIdCommand : IRequest<int>
    {
        public int roomId { get; set; }
        public class DeleteRoomsByIdCommandHandler : IRequestHandler<DeleteRoomsByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteRoomsByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteRoomsByIdCommand command, CancellationToken cancellationToken)
            {
                var Rooms = await _context.Rooms.Where(a => a.roomId == command.roomId).FirstOrDefaultAsync();
                if (Rooms == null) return default;
                _context.Rooms.Remove(Rooms);
                await _context.SaveChanges();
                return Rooms.roomId;
            }
        }
    }
}