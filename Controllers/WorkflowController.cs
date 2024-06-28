using Microsoft.AspNetCore.Mvc;
using OrchestratorServer.Models;
using OrchestratorServer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchestratorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkflowController : ControllerBase
    {
        private readonly IWorkflowService _workflowService;

        public WorkflowController(IWorkflowService workflowService)
        {
            _workflowService = workflowService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workflow>>> GetWorkflows()
        {
            return Ok(await _workflowService.GetAllWorkflowsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workflow>> GetWorkflow(int id)
        {
            var workflow = await _workflowService.GetWorkflowByIdAsync(id);
            if (workflow == null)
            {
                return NotFound();
            }
            return Ok(workflow);
        }

        [HttpPost]
        public async Task<ActionResult> AddWorkflow([FromBody] Workflow workflow)
        {
            await _workflowService.AddWorkflowAsync(workflow);
            return CreatedAtAction(nameof(GetWorkflow), new { id = workflow.Id }, workflow);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWorkflow(int id, [FromBody] Workflow workflow)
        {
            if (id != workflow.Id)
            {
                return BadRequest();
            }

            await _workflowService.UpdateWorkflowAsync(workflow);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkflow(int id)
        {
            await _workflowService.DeleteWorkflowAsync(id);
            return NoContent();
        }
    }
}
