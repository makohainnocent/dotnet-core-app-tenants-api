using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RoomsFeatures.Queries
{
    public class GetRoomsByIdQuery : IRequest<Rooms>
    {
        public int roomId { get; set; }
        public class GetRoomsByIdQueryHandler : IRequestHandler<GetRoomsByIdQuery, Rooms>
        {
            private readonly IApplicationDbContext _context;
            public GetRoomsByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Rooms> Handle(GetRoomsByIdQuery query, CancellationToken cancellationToken)
            {
                var Rooms = _context.Rooms.Where(a => a.roomId == query.roomId).FirstOrDefault();
                if (Rooms == null) return null;
                return Rooms;
            }
        }
    }
}

