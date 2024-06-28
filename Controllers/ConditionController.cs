using Microsoft.AspNetCore.Mvc;
using OrchestratorServer.Models;
using OrchestratorServer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchestratorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConditionController : ControllerBase
    {
        private readonly IConditionService _conditionService;

        public ConditionController(IConditionService conditionService)
        {
            _conditionService = conditionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Condition>>> GetConditions()
        {
            return Ok(await _conditionService.GetAllConditionsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Condition>> GetCondition(int id)
        {
            var condition = await _conditionService.GetConditionByIdAsync(id);
            if (condition == null)
            {
                return NotFound();
            }
            return Ok(condition);
        }

        [HttpPost]
        public async Task<ActionResult> AddCondition([FromBody] Condition condition)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _conditionService.AddConditionAsync(condition);
            return CreatedAtAction(nameof(GetCondition), new { id = condition.Id }, condition);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCondition(int id, [FromBody] Condition condition)
        {
            if (id != condition.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _conditionService.UpdateConditionAsync(condition);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCondition(int id)
        {
            await _conditionService.DeleteConditionAsync(id);
            return NoContent();
        }
    }
}
