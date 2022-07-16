using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsersBaseFC.Application.DTOs;
using UsersBaseFC.Application.Interfaces;

namespace UsersBaseFC.Application.CQRS.Users.Commands.Update
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Response>
    {
        private readonly IMapper mapper;
        private readonly Response response;
        private readonly IEFContext context;

        public UpdateUserHandler(IMapper mapper, Response response, IEFContext context)
        {
            this.mapper = mapper;
            this.response = response;
            this.context = context;
        }

        public async Task<Response> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            int.TryParse(request.Id, out var id);
            var user = context.Users.FirstOrDefaultAsync(e => e.Id == id).Result;

            if (user == null) 
            {
                return await response.GenerateResponse(statusCode: HttpStatusCode.BadRequest, hasError: true, message: "Usuário não encontrado");
            }  
            
            mapper.Map(request,user);

            var result = context.SaveChangesAsync(cancellationToken).Result;
            if (result <= 0)
            {
                return await response.GenerateResponse(HttpStatusCode.BadRequest, true, "Ocorreu algum problema com a operação");
            }

            return await response.GenerateResponse(HttpStatusCode.OK, false, "Usuário atualizado com sucesso!");
        }
    }
}
