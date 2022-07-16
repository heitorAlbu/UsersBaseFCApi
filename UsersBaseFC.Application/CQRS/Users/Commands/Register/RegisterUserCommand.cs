using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersBaseFC.Application.DTOs;

namespace UsersBaseFC.Application.CQRS.Users.Commands.Register
{
    public class RegisterUserCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Fone { get; set; }
        public string CPF { get; set; }
        public string BirthDate { get; set; }
        public string InclusionDate { get; set; }
        public string ChangeDate { get; set; }
        public string MotherName { get; set; }
        public bool isActive { get; set; }
    }
}
