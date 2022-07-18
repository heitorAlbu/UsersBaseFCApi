using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersBaseFC.Application.CQRS.Users.Commands.Register;
using UsersBaseFC.Application.CQRS.Users.Commands.Remove;
using UsersBaseFC.Application.CQRS.Users.Commands.Update;
using UsersBaseFC.Application.CQRS.Users.Queries.GetAll;
using UsersBaseFC.Application.CQRS.Users.Queries.GetById;
using UsersBaseFC.Application.DTOs;

namespace UsersBaseFC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<Response> GetAllUsers() 
        {
            return mediator.Send(new GetAllUsersQuery());
        }
        [HttpGet]
        [Route("GetById")]
        public Task<Response> GetById(string id)
        {
            return mediator.Send(new GetByIdUserQuery(id));
        }

        [HttpPost]
        public Task<Response> Post([FromBody] RegisterUserCommand command) 
        {
            return mediator.Send(command);
        }

        [HttpPut]
        public Task<Response> Put([FromBody] UpdateUserCommand command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("Remove")]
        public Task<Response> Remove([FromBody] RemoveUserCommand command)
        {
            return mediator.Send(command);
        }
    }
}
