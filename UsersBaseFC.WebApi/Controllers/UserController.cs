using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersBaseFC.Application.CQRS.Users.Commands.Register;
using UsersBaseFC.Application.CQRS.Users.Queries.GetAll;
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

        [HttpPost]
        public Task<Response> Post([FromBody] RegisterUserCommand command) 
        {
            return mediator.Send(command);
        }

    }
}
