using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Services;
using Model;
using API_Mapping;
using Entities;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _us;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService us, ILogger<UserController> logger)
        {
            this._us = us;
            this._logger = logger;
        }
        
        [HttpGet("/users")]
        public async Task<IActionResult> GetAll([FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] UserOrderCriteria orderCriteria = UserOrderCriteria.None)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetAll), index, count, orderCriteria);
            try
            {
                var result = (await _us.GetAll(index, count, orderCriteria)).Select(u => u.ToDTO());
                if (result == null)
                {
                    return NotFound($"No user found with the given parameters");
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }
        
        [HttpGet("/user/{pseudo}")]
        public async Task<IActionResult> GetByPseudo(string pseudo)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetByPseudo), pseudo);
            try
            {
                var result = (await _us.GetByPseudo(pseudo)).ToDTO();
                if (result == null)
                {
                    return NotFound($"Psuedo {pseudo} not found");
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
            
        }
        
        [HttpPost("/user")]
        public async Task<IActionResult> Create(User user)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(Create), user);
            try
            {
                var result = await _us.Create(user);
                if (result == false)
                {
                    return BadRequest($"User {user.Pseudo} already exists");
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
            
        }
        
        
        [HttpPut("/user/{pseudo}")]
        public async Task<IActionResult> Update(User user, string pseudo)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(Update), user, pseudo);
            try
            {
                var result = await _us.Update(user,pseudo);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
            
        }
        
        [HttpDelete("/user/{pseudo}")]
        public async Task<IActionResult> Delete(string pseudo)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(Delete), pseudo);
            try
            {
                var result = await _us.Delete(pseudo);
                if (result == false)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }
   
        [HttpGet("/articleUsers")]
    public async Task<IActionResult> GetAllArticleUsers()
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetAllArticleUsers), "");
        try
        {
            var result = (await _us.GetAllArticleUsers()).Select(u => u.ToDTO());
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        catch (Exception error)
        {
            _logger.LogError(error.Message);
            return BadRequest(error.Message);
        }
    }
         
    [HttpGet("/user/{pseudo}/article")]
    public async Task<IActionResult> GetArticleUser(string pseudo)
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetArticleUser), pseudo);
        try
        {
            var result = (await _us.GetArticleUser(pseudo)).Select(a => a.ToDTO());
            if (result == null)
            {
                return NoContent();
            }
            return Ok(result);
        }
        catch (Exception error)
        {
            _logger.LogError(error.Message);
            return BadRequest(error.Message);
        }
    }
    
    [HttpPost("/user/article")]
    public async Task<IActionResult> CreateArticleUser(ArticleUserEntity articleUser)
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(CreateArticleUser), articleUser);
        try
        {
            Console.WriteLine(articleUser);
            var result = await _us.CreateArticleUser(articleUser);
            if (result == null)
            {
                return BadRequest($"ArticleUser {articleUser.UserEntityPseudo} already exists");
            }
            return Ok(result);
        }
        catch (Exception error)
        {
            _logger.LogError(error.Message);
            return BadRequest(error.Message);
        }
    }
    
    [HttpDelete("/user/{pseudo}/article")]
    public async Task<IActionResult> DeleteArticleUser(string pseudo)
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(DeleteArticleUser), pseudo);
        try
        {
            var result = await _us.DeleteArticleUser(pseudo);
            if (!result)
            {
                return BadRequest($"ArticleUser {pseudo} does not exist");
            }
            return Ok(result);
        }
        catch (Exception error)
        {
            _logger.LogError(error.Message);
            return BadRequest(error.Message);
        }
    }
    
    [HttpPut("/user/{pseudo}/article")]
    public async Task<IActionResult> UpdateArticleUser(ArticleUserEntity articleUser)
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(UpdateArticleUser), articleUser);
        try
        {
            var result = await _us.UpdateArticleUser(articleUser);
            if (!result)
            {
                return BadRequest($"ArticleUser {articleUser.UserEntityPseudo} does not exist");
            }
            return Ok(result);
        }
        catch (Exception error)
        {
            _logger.LogError(error.Message);
            return BadRequest(error.Message);
        }
    }
        
        
    }
}
