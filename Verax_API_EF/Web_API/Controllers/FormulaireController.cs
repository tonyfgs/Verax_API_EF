using Microsoft.AspNetCore.Mvc;
using Web_API.Model;
using API_Services;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulaireController : ControllerBase
    {
        private readonly IFormulaireService _form;
        private Mapper.Mapper map = new Mapper.Mapper();

        public FormulaireController(IFormulaireService iform)
        {
            this._form = iform;
        }

        [HttpGet]
        public async Task<List<Formulaire>> GetAllForm()
        {
            var AllForms = await _form.GetAllForm();
            return AllForms;
        }

    }
}
