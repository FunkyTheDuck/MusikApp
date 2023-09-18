using ApiRepository;
using Microsoft.AspNetCore.Mvc;

namespace MusikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistInfoController : Controller
    {
        IArtistInfoRepository repo { get; set; }
        public ArtistInfoController(IArtistInfoRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                return Ok(await repo.GetArtistLikeAndSkipByIdAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
