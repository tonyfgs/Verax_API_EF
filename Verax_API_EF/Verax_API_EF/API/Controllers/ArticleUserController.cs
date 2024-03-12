using API_Mapping;
using API_Services;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticleUserController : ControllerBase
{
    
    private readonly IArticleUserService _us;
    private readonly ILogger<ArticleUserController> _logger;
    public ArticleUserController(IArticleUserService us, ILogger<ArticleUserController> logger)
    {
        this._us = us;
        this._logger = logger;
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
            var result =  await _us.GetArticleUser(pseudo);
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
    
    [HttpPost("/user/{pseudo}/article")]
    public async Task<IActionResult> CreateArticleUser(ArticleUserEntity articleUser)
    {
        _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(CreateArticleUser), articleUser);
        try
        {
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