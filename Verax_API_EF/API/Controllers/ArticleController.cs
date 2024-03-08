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
        
        [HttpGet("/articles")]
        public async Task<IActionResult> GetAllArticles()
        {
            var result = await _articleService.GetAllArticles();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [HttpGet("/article/{id}")]
        public async Task<ArticleEntity?> GetArticleById(int id)
        {
            var result =  await _articleService.GetArticleById(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }
        
        
        
        [HttpPost("/article")]
        public async Task<ArticleEntity?> CreateArticle(long id, string title, string description, string author, string date, int lectureTime)
        {
            return await _articleService.CreateArticle(id, title, description, author, date, lectureTime);
        }

        [HttpDelete("/article/{id}")]
        public async Task<ArticleEntity?> DeleteArticle(long id)
        {
            return await _articleService.DeleteArticle(id);
        }
    
        [HttpPut("/article/{id}")]
        public async Task<bool> UpdateArticle(long id, ArticleEntity? a)
        {
            return await _articleService.UpdateArticle(id, a); 
        }
        
        
    }
}
