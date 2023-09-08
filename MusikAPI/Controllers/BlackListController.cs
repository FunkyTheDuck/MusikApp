using ApiModels;
using ApiRepository;
using Microsoft.AspNetCore.Mvc;

namespace MusikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlackListController : ControllerBase
    {
        IBlackListRepository repo { get; set; }
        public BlackListController(IBlackListRepository repo)
        {
            this.repo = repo;
        }
        [HttpPost]
        public async Task<IActionResult> Post(BlackList skippedSong)
        {
            if (skippedSong != null)
            {
                bool checkIfSucces = false;
                try
                {
                    checkIfSucces = await repo.SkipSongAsync(skippedSong);
                }
                catch
                {
                    NotFound();
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
