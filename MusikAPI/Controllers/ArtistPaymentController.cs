using ApiDTOModels;
using ApiRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MusikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistPaymentController : ControllerBase
    {
        IArtistPaymentRepository repo { get; set; }
        public ArtistPaymentController(IArtistPaymentRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetArtistPayment()
        {
            return Ok(await repo.GetArtistPayments());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtistPayment(int id)
        {
            return Ok(await repo.GetArtistPayments(id));
        }
        [HttpPost]
        public async Task<IActionResult> PostArtistPayment(DtoArtistPayment artistPayment)
        {
            bool checkIfSucces = false;
            try
            {
                checkIfSucces = await repo.Create(artistPayment);
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
        public async Task<IActionResult> PutArtistPayment(DtoArtistPayment artistPayment)
        {
            if (artistPayment != null)
            {
                bool checkIfSucces = false;
                try
                {
                    checkIfSucces = await repo.Update(artistPayment);
                }
                catch
                {
                    return NotFound();
                }
                if (checkIfSucces)
                {
                    return Ok(await repo.Update(artistPayment));
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
