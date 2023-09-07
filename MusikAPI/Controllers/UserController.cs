using ApiModels;
using ApiRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MusikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserRepository repo { get; set; }
        public UserController(IUserRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await repo.GetUsers());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            return Ok(await repo.GetUsers(id));
        }
        [HttpPost]
        public async Task<IActionResult> PostUsers(User user)
        {
            bool checkIfSucces = false;
            try
            {
                checkIfSucces = await repo.Create(user);
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
        public async Task<IActionResult> PutUser(User user)
        {
            if (user != null)
            {
                bool checkIfSucces = false;
                try
                {
                    checkIfSucces = await repo.Update(user);
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await repo.Delete(id));
        }
    }
}
