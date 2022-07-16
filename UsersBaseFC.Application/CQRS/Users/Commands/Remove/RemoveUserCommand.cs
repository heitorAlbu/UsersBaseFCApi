using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersBaseFC.Application.DTOs;

namespace UsersBaseFC.Application.CQRS.Users.Commands.Remove
{
    public class RemoveUserCommand : IRequest<Response>
    {
        public string Id { get; set; }

    }
}
