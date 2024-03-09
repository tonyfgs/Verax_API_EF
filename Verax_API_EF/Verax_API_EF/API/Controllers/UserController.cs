using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Services;
using Model;
using API_Mapping;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _us;

        public UserController(IUserService us)
        {
            this._us = us;
        }
        
        [HttpPost("/user")]
        public async Task<bool> Create(User user)
        {
            return await _us.Create(user);
        }
        
        
        [HttpPut("/user/{pseudo}")]
        public async Task<bool> Update(User user, string pseudo)
        {
            return await _us.Update(user,pseudo);
        }
        
        [HttpDelete("/user/{pseudo}")]
        public async Task<bool> Delete(string pseudo)
        {
            return await _us.Delete(pseudo);
        }
        
        [HttpGet("/user/{pseudo}")]
        public async Task<IActionResult> GetByPseudo(string pseudo)
        {
            var result = (await _us.GetByPseudo(pseudo)).ToDTO();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [HttpGet("/users")]
        public async Task<IActionResult> GetAll([FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] UserOrderCriteria orderCriteria = UserOrderCriteria.None)
        {
            var result = (await _us.GetAll(index, count, orderCriteria)).Select(u => u.ToDTO());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }
    }
}
