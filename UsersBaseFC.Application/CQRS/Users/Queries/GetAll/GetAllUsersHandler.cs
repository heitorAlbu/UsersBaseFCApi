using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersBaseFC.Application.DTOs;
using UsersBaseFC.Application.Interfaces;

namespace UsersBaseFC.Application.CQRS.Users.Queries.GetAll
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, Response>
    {
        private readonly IMapper mapper;
        private readonly Response response;
        private readonly IEFContext context;

        public GetAllUsersHandler(IMapper mapper, Response response, IEFContext context)
        {
            this.mapper = mapper;
            this.response = response;
            this.context = context;
        }
        public async Task<Response> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = mapper.Map<List<UserDTO>>(context.Users.ToListAsync().Result);

            return await response.GenerateResponse(collection: users);
        }
    }
}
