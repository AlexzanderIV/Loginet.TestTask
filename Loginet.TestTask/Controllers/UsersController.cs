using System.Threading.Tasks;
using Loginet.TestTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loginet.TestTask.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/users
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetAllUsersAsync();
            if (result.Content != null)
            {
                return Ok(result.Content);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            if (result.Content != null)
            {
                return Ok(result.Content);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        // GET api/users/5/albums
        [HttpGet("{id}/albums")]
        public async Task<IActionResult> GetAlbums(int id)
        {
            var result = await _userService.GetAlbumsByUserIdAsync(id);
            if (result.Content != null)
            {
                return Ok(result.Content);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }
    }
}
