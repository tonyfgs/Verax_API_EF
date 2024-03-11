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
        
        private readonly IArticleService _articleService;
        
        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllArticles([FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] ArticleOrderCriteria orderCriterium = ArticleOrderCriteria.None)
        {
            var result = (await _articleService.GetAllArticles(index, count, orderCriterium)).Select(a => a.ToDTO());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [HttpGet("/article/{id}")]
        public async Task<Article?> GetArticleById(int id, [FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] ArticleOrderCriteria orderCriterium = ArticleOrderCriteria.None)
        {
            var result =  await _articleService.GetArticleById(id, index, count, orderCriterium);
            if (result == null)
            {
                return null;
            }
            return result;
        }
        
        
        
        [HttpPost("/article")]
        public async Task<Article?> CreateArticle(Article article)
        {
            return await _articleService.CreateArticle(article);
        }

        [HttpDelete("/article/{id}")]
        public async Task<Article?> DeleteArticle(long id)
        {
            return await _articleService.DeleteArticle(id);
        }
    
        [HttpPut("/article/{id}")]
        public async Task<bool> UpdateArticle(long id, Article? a)
        {
            return await _articleService.UpdateArticle(id, a); 
        }
        
        
    }
}
