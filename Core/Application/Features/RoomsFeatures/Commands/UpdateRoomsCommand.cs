using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RoomsFeatures.Commands
{
    public class UpdateRoomsCommand : IRequest<int>
    {
        public int roomId { get; set; }
        public string room { get; set; }
        public string price{ get; set; }
        public int apartmentId { get; set; }
        public class UpdateRoomsCommandHandler : IRequestHandler<UpdateRoomsCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateRoomsCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateRoomsCommand command, CancellationToken cancellationToken)
            {
                var Rooms = _context.Rooms.Where(a => a.roomId == command.roomId).FirstOrDefault();

                if (Rooms == null)
                {
                    return default;
                }
                else
                {
                    Rooms.room = command.room;
                    Rooms.price = command.price;
                    Rooms.apartmentId = command.apartmentId;
                    await _context.SaveChanges();
                    return Rooms.roomId;
                }
            }
        }
    }
}