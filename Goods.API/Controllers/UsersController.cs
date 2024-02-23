using Goods.API.Contracts;
using Goods.Core.Abstractions;
using Goods.Core.Models;
using Goods.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;


namespace Goods.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _userService;

        public UsersController(IUsersService userService) => _userService = userService;

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _userService.GetAllUsers();

            var response = users.Select(u => new UsersResponse(u.Id, u.Name, u.Surname, u.Mail, u.Password));

            return Ok(response);

        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UsersRequest request)
        {

            var (user, error) = Users.Create(Guid.NewGuid(), request.Name, request.Surname, request.Mail, request.password);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var userId = await _userService.Create(user);
            if (userId.Equals(Guid.Empty))
            {
                return BadRequest("Mail is exist");
            }
            return Ok(userId);

        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Users>> UpdateUsers(Guid id, [FromBody] UsersRequest request)
        {
            var userId = await _userService.Update(id,request.Name, request.Surname,request.Mail, request.password);

            return Ok(userId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var userId = await _userService.Delete(id);

            return Ok($"user with id {userId} removed");
        }
    }
}
