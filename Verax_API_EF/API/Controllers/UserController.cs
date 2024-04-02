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
        //private readonly IUserService _us;
        private readonly IDataManager _dataManager;
        private readonly ILogger<UserController> _logger;
        public UserController(IDataManager dataManager, ILogger<UserController> logger)
        {
            this._logger = logger;
            this._dataManager = dataManager;
        }
        
        [HttpGet("/users")]
        public async Task<IActionResult> GetAll([FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] UserOrderCriteria orderCriteria = UserOrderCriteria.None)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetAll), index, count, orderCriteria);
            try
            {
                var result = (await _dataManager.UserService.GetAll(index, count, orderCriteria)).Select(u => u.ToDTO());
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
                var result = (await _dataManager.UserService.GetByPseudo(pseudo)).ToDTO();
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
                var result = (await _dataManager.UserService.Create(user)).ToDTO();
                if (result == null)
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
                var result = (await _dataManager.UserService.Update(user, pseudo)).ToDTO();
                if (result == null)
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
                var result = (await _dataManager.UserService.Delete(pseudo)).ToDTO();
                if (result == null)
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
   
        [HttpGet("/user/article/users")]
    public async Task<IActionResult> GetAllArticleUsers()
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetAllArticleUsers), "");
        try
        {
            var result = (await _dataManager.UserService.GetAllArticleUsers()).Select(u => u.ToDTO());
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
         
    [HttpGet("/user/{pseudo}/articles")]
    public async Task<IActionResult> GetArticleUser(string pseudo)
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetArticleUser), pseudo);
        try
        {
            var result = (await _dataManager.UserService.GetArticleUser(pseudo)).Select(a => a.ToDTO());
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
            var result = await _dataManager.UserService.CreateArticleUser(articleUser);
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
    
    [HttpDelete("/user/{pseudo}/{id}")]
    public async Task<IActionResult> DeleteArticleUser(string pseudo, long id)
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(DeleteArticleUser), pseudo);
        try
        {
            var result = await _dataManager.UserService.DeleteArticleUser(pseudo, id);
            if (!result)
            {
                return BadRequest($"User {pseudo} or {id} does not exist");
            }
            return Ok(result);
        }
        catch (Exception error)
        {
            _logger.LogError(error.Message);
            return BadRequest(error.Message);
        }
    }
    
    [HttpPut("/user/{pseudo}/{oldId}")]
    public async Task<IActionResult> UpdateArticleUser(ArticleUserEntity articleUser, long oldId)
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(UpdateArticleUser), articleUser);
        try
        {
            var existingEntity = (await _dataManager.UserService.GetArticleUser(articleUser.UserEntityPseudo)).Select(a => a.ToDTO());

            if (existingEntity == null)
            {
                return NotFound($"ArticleUser {articleUser.UserEntityPseudo} does not exist");
            }

            var deleteResult = await _dataManager.UserService.DeleteArticleUser(articleUser.UserEntityPseudo, oldId);

            if (!deleteResult)
            {
                return BadRequest($"Failed to delete ArticleUser {articleUser.UserEntityPseudo}");
            }

            var createResult = await _dataManager.UserService.CreateArticleUser(articleUser);

            if (createResult == null)
            {
                return BadRequest($"Failed to create ArticleUser {articleUser.UserEntityPseudo}");
            }

            return Ok(createResult);
        }
        catch (Exception error)
        {
            _logger.LogError(error.Message);
            return BadRequest(error.Message);
        }
    }
    }
}
