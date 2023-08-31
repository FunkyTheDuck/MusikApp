using ApiDTOModels;
using ApiRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        ISongsRepository repo {  get; set; }
        public SongsController(ISongsRepository repo) 
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            return Ok(await repo.GetSongs());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSong(int id)
        {
            return Ok(await repo.GetSongs(id));
        }
        [HttpPost]
        public async Task<IActionResult> PostSongs(DtoSong songs)
        {
            bool checkIfSucces = false;
            try
            {
                checkIfSucces = await repo.Create(songs);
            }
            catch
            {
                return NotFound();
            }
            if (checkIfSucces)
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> PutSongs(DtoSong songs)
        {
            if (songs != null)
            {
                bool checkIfSucces = false;
                try
                {
                    checkIfSucces = await repo.Update(songs);
                }
                catch
                {
                    return NotFound();
                }
                if (checkIfSucces)
                {
                    return Ok(await repo.Update(songs));
                }
            }
            return BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await repo.Delete(id));
        }
    }
}
