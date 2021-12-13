using Application;
//using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.RoomsFeatures.Queries
{
    public class GetAllRoomsQuery : IRequest<IEnumerable<Rooms>>
    {

        public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<Rooms>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllRoomsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Rooms>> Handle(GetAllRoomsQuery query, CancellationToken cancellationToken)
            {
                var RoomsList = await _context.Rooms.ToListAsync();
                if (RoomsList == null)
                {
                    return null;
                }
                return RoomsList.AsReadOnly();
            }
        }
    }
}