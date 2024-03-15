using API_Mapping;
using API_Services;
using Microsoft.AspNetCore.Mvc;
using Model;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        
        //private readonly IArticleService _articleService;
        private readonly IDataManager _dataManager;
        private readonly ILogger<ArticleController> _logger;
        
        public ArticleController(IDataManager dataManager, ILogger<ArticleController> logger)
        {
            this._dataManager = dataManager;
            this._logger = logger;
        }
        
        [Route("/articles")]
        [HttpGet]
        public async Task<IActionResult> GetAllArticles([FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] ArticleOrderCriteria orderCriterium = ArticleOrderCriteria.None)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetAllArticles), index, count, orderCriterium);
            try 
            {
                var result = (await _dataManager.ArticleService.GetAllArticles(index, count, orderCriterium)).Select(a => a.ToDTO());
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
        
        [HttpGet("/article/{id}")]
        public async Task<IActionResult> GetArticleById(int id)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetArticleById), id);
            try 
            {
                var result = (await _dataManager.ArticleService.GetArticleById(id)).ToDTO();
                if (result == null)
                {
                    return NotFound($"Article ID {id} not found");
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }
        
        
        
        [HttpPost("/article")]
        public async Task<IActionResult> CreateArticle(Article article)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(CreateArticle), article);
            try 
            {
                var result = (await _dataManager.ArticleService.CreateArticle(article)).ToDTO();
                if (result == null)
                {
                    return BadRequest($"Article not created");
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }

        [HttpDelete("/article/{id}")]
        public async Task<IActionResult> DeleteArticle(long id)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(DeleteArticle), id);
            try 
            {
                var result = await _dataManager.ArticleService.DeleteArticle(id);
                if (result == null)
                {
                    return NotFound($"Article ID {id} not found");
                }
                return Ok(result.ToDTO());
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }
    
        [HttpPut("/article/{id}")]
        public async Task<IActionResult> UpdateArticle(long id, Article? a)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(UpdateArticle), id, a);
            try 
            {
                var result = (await _dataManager.ArticleService.UpdateArticle(id, a)).ToDTO();
                if (result == null)
                {
                    return NotFound($"Article ID {id} not found");
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
