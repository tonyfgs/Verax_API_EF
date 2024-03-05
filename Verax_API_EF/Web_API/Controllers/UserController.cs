using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Model;
using API_Services;


namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<User>? logger;

        private readonly IUserService _us;

        public UserController(IUserService us)
        {
            this._us = us;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _us.GetAll());

        }

        // GET : users/id
        [HttpGet("{pseudo}", Name = "GetUserByPseudo")]
        public async Task<IActionResult> GetUser(string pseudo)
        {
            var user = _us.GetByPseudo(pseudo);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var check = await _us.Create(user);
            if (!check)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetUser), new { Pseudo = user.Pseudo}, user);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string pseudo)
        {
            var check = await _us.Delete(pseudo);
            if (!check)
            {
                return NotFound();
            }
            return Ok(pseudo);
        }

        [HttpPut]
        
        public async Task<IActionResult> UpdateUser(User user)
        {
            var check = await _us.Update(user);
            if (!check)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
