using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UsersFeatures.Queries
{
    public class GetUsersByIdQuery : IRequest<Users>
    {
        public int userId { get; set; }
        public class GetUsersByIdQueryHandler : IRequestHandler<GetUsersByIdQuery, Users>
        {
            private readonly IApplicationDbContext _context;
            public GetUsersByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Users> Handle(GetUsersByIdQuery query, CancellationToken cancellationToken)
            {
                var Users = _context.Users.Where(a => a.userId == query.userId).FirstOrDefault();
                if (Users == null) return null;
                return Users;
            }
        }
    }
}

