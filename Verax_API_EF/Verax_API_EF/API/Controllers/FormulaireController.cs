using Microsoft.AspNetCore.Mvc;
using API_Services;
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet("/forms/{id}")]
        public Task<IEnumerable<Formulaire?>> GetAllForm()
        {
            throw new NotImplementedException();
        }
        
        [HttpGet("{id}")]
        public Task<Formulaire?> GetById(long id)
        {
            throw new NotImplementedException();
        }
        
        [HttpPost]
        public Task<Formulaire?> CreateForm(Formulaire formulaire)
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete("{id}")]
        public Task<bool> DeleteForm(long id)
        {
            throw new NotImplementedException();
        }
        
        [HttpPut("{id}")]
        public Task<bool> UpdateForm(long id, Formulaire formulaire)
        {
            throw new NotImplementedException();
        }
    }
}