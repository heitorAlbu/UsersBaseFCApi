using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using UsersBaseFC.Application.DTOs;
using UsersBaseFC.Application.Interfaces;
using UsersBaseFC.Domain.Entities;

namespace UsersBaseFC.Application.CQRS.Users.Commands.Register
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Response>
    {
        private readonly IMapper mapper;
        private readonly Response response;
        private readonly IEFContext context;

        public RegisterUserHandler(IMapper mapper, Response response, IEFContext context)
        {
            this.mapper = mapper;
            this.response = response;
            this.context = context;
        }
        public async Task<Response> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = mapper.Map<User>(request);
            await context.Users.AddAsync(user);
            var result = context.SaveChangesAsync(cancellationToken).Result;
            if (result > 0)
            {
                return await response.GenerateResponse(HttpStatusCode.Created, false, "Salvo com sucesso!");
            }
            return await response.GenerateResponse(HttpStatusCode.BadRequest, false, "Não foi possível criar o registro");
        }
    }
}
