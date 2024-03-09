using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Services;
using Model;


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
        public Task<bool> Create(User user)
        {
            throw new NotImplementedException();
        }
        
        
        [HttpPut("/user/{pseudo}")]
        public Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete("/user/{pseudo}")]
        public Task<bool> Delete(string pseudo)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("/user/{pseudo}")]
        public Task<User?> GetByPseudo(string pseudo)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("/users")]
        public Task<IEnumerable<User?>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
