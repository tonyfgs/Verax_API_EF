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
        //private readonly IFormulaireService _form;
        private readonly IDataManager _dataManager;
        private readonly ILogger<FormulaireController> _logger;

        public FormulaireController(IDataManager dataManager, ILogger<FormulaireController> logger)
        {
            this._dataManager = dataManager;
            this._logger = logger;
        }

        [HttpGet("/formulaires")]
        public async Task<IActionResult> GetAllForm([FromQuery] int index = 0, [FromQuery] int count = 10, [FromQuery] FormOrderCriteria orderCriteria = FormOrderCriteria.None)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetAllForm), index, count, orderCriteria);
            try
            {
                var result = (await _dataManager.FormulaireService.GetAllForm(index, count, orderCriteria)).Select(f => f.ToDTO());
                if (result == null)
                {
                    return NotFound($"No form found");
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
            
        }
        
        [HttpGet("/formulaire/{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(GetById), id);
            try
            {
                var result = (await _dataManager.FormulaireService.GetById(id)).ToDTO();
                if (result == null)
                {
                    return NotFound($"form ID {id} not found");
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
           
            
        }
        
        [HttpPost ("/formulaire")]
        public async Task<IActionResult> CreateForm(Formulaire formulaire)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(CreateForm), formulaire);
            try
            {
                var result = (await _dataManager.FormulaireService.CreateForm(formulaire)).ToDTO();
                if (result == null)
                {
                    return BadRequest($"Form Id {formulaire.Id} already exists");
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }
        
        [HttpDelete("/formulaire/{id}")]
        public async Task<IActionResult> DeleteForm(long id)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(DeleteForm), id);
            try
            {
                var result = (await _dataManager.FormulaireService.DeleteForm(id)).ToDTO();
                if (result == null)
                {
                    return NotFound($"Form Id {id} not found");
                }
                return Ok(result);
            }
            catch (Exception error)
            {
                _logger.LogError(error.Message);
                return BadRequest(error.Message);
            }
        }
        
        [HttpPut("/formulaire/{id}")]
        public async Task<IActionResult> UpdateForm(long id, Formulaire formulaire)
        {
            _logger.LogInformation("Executing {Action} - with parameters: {Parameters}",nameof(UpdateForm), formulaire);

            try
            {
                var result = (await _dataManager.FormulaireService.UpdateForm(id, formulaire)).ToDTO();
                if (result == null)
                {
                    return NotFound($"form Id {id} not found");
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