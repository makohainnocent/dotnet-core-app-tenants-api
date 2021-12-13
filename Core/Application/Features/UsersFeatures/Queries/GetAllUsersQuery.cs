using Application;
//using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UsersFeatures.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<Users>>
    {

        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<Users>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllUsersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Users>> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
            {
                var UsersList = await _context.Users.ToListAsync();
                if (UsersList == null)
                {
                    return null;
                }
                return UsersList.AsReadOnly();
            }
        }
    }
}