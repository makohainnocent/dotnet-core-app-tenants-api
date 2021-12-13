using Application;
//using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.UsersFeatures.Commands
{
    public class CreateUsersCommand : IRequest<int>
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public class CreateUsersCommandHandler : IRequestHandler<CreateUsersCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateUsersCommandHandler(IApplicationDbContext context)
            {
                this._context = context;
            }
            public async Task<int> Handle(CreateUsersCommand command, CancellationToken cancellationToken)
            {
                var Users = new Users();
                Users.userName = command.userName;
                Users.password = command.password;
                _context.Users.Add(Users);
                await _context.SaveChanges();
                return Users.userId;
            }
        }
    }
}



