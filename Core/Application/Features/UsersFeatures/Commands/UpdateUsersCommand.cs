using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UsersFeatures.Commands
{
    public class UpdateUsersCommand : IRequest<int>
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public class UpdateUsersCommandHandler : IRequestHandler<UpdateUsersCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateUsersCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateUsersCommand command, CancellationToken cancellationToken)
            {
                var Users = _context.Users.Where(a => a.userId == command.userId).FirstOrDefault();

                if (Users == null)
                {
                    return default;
                }
                else
                {
                    Users.userName = command.userName;
                    Users.password = command.password;
                    await _context.SaveChanges();
                    return Users.userId;
                }
            }
        }
    }
}