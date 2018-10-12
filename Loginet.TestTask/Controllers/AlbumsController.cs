using System.Threading.Tasks;
using Loginet.TestTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Loginet.TestTask.Controllers
{
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        // GET api/albums
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _albumService.GetAllAlbumsAsync();
            if (result.Content != null)
            {
                return Ok(result.Content);
            }
            else
            {
                return BadRequest(result.Error);
            }
        }

        // GET api/albums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _albumService.GetAlbumByIdAsync(id);
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
