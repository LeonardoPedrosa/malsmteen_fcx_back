using FCx.Domain.Entities;
using FCx.Services;
using Microsoft.AspNetCore.Mvc;

namespace FCx.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 100)
        {
            if (page < 1 || pageSize < 1)
                return BadRequest("Invalid page or pageSize");

            var pager = new Pager(page, pageSize); 
            var users = await _userService.GetAllUsersAsync(pager);

            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync(User user)
        {
            var result = await _userService.AddAsync(user);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var result = await _userService.GetByIdAsync(id);

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<User>> UpdateAsync(User user)
        {
            var userResponse = await _userService.GetByIdAsync(user.Id);

            if (userResponse is null)
                return NotFound();

            var result = await _userService.UpdateAsync(user);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var userResponse = await _userService.GetByIdAsync(id);

            if (userResponse is null)
                return NotFound();

            await _userService.DeleteAsync(id);
                return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteSelectedAsync(int[] userIds)
        {
            if (userIds == null || userIds.Length == 0)
                return NotFound();

            await _userService.DeleteSelectedAsync(userIds);
            return Ok();
        }
    }
}
