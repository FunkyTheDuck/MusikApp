using ApiModels;
using ApiRepository;
using Microsoft.AspNetCore.Mvc;

namespace MusikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhiteListController : ControllerBase
    {
        IWhiteListRepository repo { get; set; }
        public WhiteListController(IWhiteListRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet("{userId}")] 
        public async Task<IActionResult> Get(int userId)
        {
            try
            {
                return Ok(await repo.GetUsersLikedSongs(userId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Post(WhiteList likedSong)
        {
            if (likedSong != null)
            {
                bool checkIfSucces = false;
                try
                {
                    checkIfSucces = await repo.LikeSongAsync(likedSong);
                }
                catch
                {
                    return NotFound();
                }
                if (checkIfSucces)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
