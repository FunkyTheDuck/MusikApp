using ApiModels;
using ApiRepository;
using Microsoft.AspNetCore.Mvc;

namespace MusikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : Controller
    {
        SettingsRepository repo { get; set; }
        public SettingsController()
        {
            repo = new SettingsRepository();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserSettingsAsync(int id)
        {
            try
            {
                return Ok(await repo.GetUsersSettingsAsync(id));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserSettingsAsync(Settings setting)
        {
            if(setting != null)
            {
                bool checkIfSucces = false;
                try
                {
                    checkIfSucces = await repo.UpdateUserSettingsAsync(setting);
                }
                catch
                {
                    return NotFound();
                }
                if(checkIfSucces)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}