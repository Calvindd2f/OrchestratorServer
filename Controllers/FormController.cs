using Microsoft.AspNetCore.Mvc;
using OrchestratorServer.Services;
using System.Threading.Tasks;

namespace OrchestratorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly IWorkflowExecutionService _workflowExecutionService;

        public FormController(IWorkflowExecutionService workflowExecutionService)
        {
            _workflowExecutionService = workflowExecutionService;
        }

        [HttpPost("{packageId}/submit")]
        public async Task<ActionResult> SubmitForm(int packageId, [FromBody] string formData)
        {
            if (string.IsNullOrWhiteSpace(formData))
            {
                return BadRequest("Form data cannot be empty.");
            }

            await _workflowExecutionService.PauseWorkflowForInputAsync(packageId, formData);
            return NoContent();
        }

        [HttpGet("{packageId}/status")]
        public async Task<ActionResult> GetWorkflowStatus(int packageId)
        {
            var status = await _workflowExecutionService.GetWorkflowStatusAsync(packageId);
            if (status == null)
            {
                return NotFound();
            }
            return Ok(status);
        }

        [HttpGet("{packageId}/definition")]
        public async Task<ActionResult<FormDefinition>> GetFormDefinition(int packageId)
        {
            var formDefinition = await _workflowExecutionService.GetFormDefinitionAsync(packageId);
            if (formDefinition == null)
            {
                return NotFound();
            }
            return Ok(formDefinition);
        }
    }
}
