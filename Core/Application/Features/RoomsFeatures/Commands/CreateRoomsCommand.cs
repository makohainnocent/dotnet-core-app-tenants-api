using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RoomsFeatures.Commands
{
    public class CreateRoomsCommand : IRequest<int>
    {
        public int roomId { get; set; }
        public string room { get; set; }
        public string price{ get; set; }
        public int apartmentId { get; set; }
        public class CreateRoomsCommandHandler : IRequestHandler<CreateRoomsCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateRoomsCommandHandler(IApplicationDbContext context)
            {
                this._context = context;
            }
            public async Task<int> Handle(CreateRoomsCommand command, CancellationToken cancellationToken)
            {
                var Rooms = new Rooms();
                Rooms.room = command.room;
                Rooms.price = command.price;
                Rooms.apartmentId = command.apartmentId;
                _context.Rooms.Add(Rooms);
                await _context.SaveChanges();
                return Rooms.roomId;
            }
        }
    }
}



