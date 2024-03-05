using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API.Model;
using API_Services;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _as;
        private Mapper.Mapper map = new Mapper.Mapper();
        
        public ArticleController(IArticleService articleService)
        {
            this._as = articleService;
        }
        
        [HttpGet("Articles")]
        
        public async Task<IActionResult> GetAllArticle()
        {
            return Ok(await _as.GetAllArticles());

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _as.GetById(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }
        
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(ArticleDTO article)
        {
            var newArticle = await _as.Create(article);
            if (newArticle == null) return BadRequest();
            var newArticleEnt = map.ArtDTOToEntity(article);
            return CreatedAtAction(nameof(GetArticle), new { id = newArticle.Id}, newArticleEnt);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> PutArticle(long id , [FromBody]ArticleDTO article)
        {
            var check = await _as.Update(id,article);
            if (!check) return NotFound();
            var articleEnt = map.ArtDTOToEntity(article);
            return articleEnt;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> DeleteArticle(long id)
        {
            var articleDeleted = await _as.Delete(id);
            if (articleDeleted == null)return NotFound();
            articleDeleted = map.ArtEntityToDTO(articleDeleted);
            return Ok(articleDeleted);

        }
        
    }
}
