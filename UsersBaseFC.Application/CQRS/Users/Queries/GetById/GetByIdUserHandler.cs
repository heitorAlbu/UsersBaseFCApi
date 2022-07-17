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

namespace UsersBaseFC.Application.CQRS.Users.Queries.GetById
{
    public class GetByIdUserHandler : IRequestHandler<GetByIdUserQuery, Response>
    {
        private readonly IMapper mapper;
        private readonly Response response;
        private readonly IEFContext context;
        public GetByIdUserHandler(IMapper mapper, Response response, IEFContext context)
        {
            this.mapper = mapper;
            this.response = response;
            this.context = context;
        }
        public async Task<Response> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            int.TryParse(request.Id, out int userId);   

            var user = mapper.Map<UserDTO>(context.Users.FindAsync(userId).Result);

            if (user == null)
            {
                return await response.GenerateResponse(HttpStatusCode.BadRequest, false, "Não foi possível encontrar o usuário");
            }
            return await response.GenerateResponse(collection: user);
        }
    }
}
