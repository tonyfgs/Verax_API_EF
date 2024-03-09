using Microsoft.AspNetCore.Mvc;
using API_Services;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API_Mapping;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormulaireController : ControllerBase
    {
        private readonly IFormulaireService _form;

        public FormulaireController(IFormulaireService iform)
        {
            this._form = iform;
        }

        [HttpGet("/forms")]
        public async Task<IActionResult> GetAllForm([FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] FormOrderCriteria orderCriteria = FormOrderCriteria.None)
        {
            var result = (await _form.GetAllForm(index, count, orderCriteria)).Select(f => f.ToDTO());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var result = (await _form.GetById(id)).ToDTO();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<Formulaire?> CreateForm(Formulaire formulaire)
        {
            return await _form.CreateForm(formulaire);
        }
        
        [HttpDelete("{id}")]
        public async Task<bool> DeleteForm(long id)
        {
            return await _form.DeleteForm(id);
        }
        
        [HttpPut("{id}")]
        public async Task<bool> UpdateForm(long id, Formulaire formulaire)
        {
            return await _form.UpdateForm(id, formulaire);
        }
    }
}