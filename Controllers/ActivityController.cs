using Microsoft.AspNetCore.Mvc;
using OrchestratorServer.Models;
using OrchestratorServer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchestratorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            return Ok(await _activityService.GetAllActivitiesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult> AddActivity([FromBody] Activity activity)
        {
            await _activityService.AddActivityAsync(activity);
            return CreatedAtAction(nameof(GetActivity), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateActivity(int id, [FromBody] Activity activity)
        {
            if (id != activity.Id)
            {
                return BadRequest();
            }

            await _activityService.UpdateActivityAsync(activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(int id)
        {
            await _activityService.DeleteActivityAsync(id);
            return NoContent();
        }
    }
}
