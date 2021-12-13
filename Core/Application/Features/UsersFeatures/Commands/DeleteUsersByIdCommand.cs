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

namespace Application.Features.UsersFeatures.Commands
{
    public class DeleteUsersByIdCommand : IRequest<int>
    {
        public int userId { get; set; }
        public class DeleteUsersByIdCommandHandler : IRequestHandler<DeleteUsersByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteUsersByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteUsersByIdCommand command, CancellationToken cancellationToken)
            {
                var Users = await _context.Users.Where(a => a.userId == command.userId).FirstOrDefaultAsync();
                if (Users == null) return default;
                _context.Users.Remove(Users);
                await _context.SaveChanges();
                return Users.userId;
            }
        }
    }
}