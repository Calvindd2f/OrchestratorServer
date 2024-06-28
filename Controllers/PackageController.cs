using Microsoft.AspNetCore.Mvc;
using OrchestratorServer.Models;
using OrchestratorServer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchestratorServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackages()
        {
            return Ok(await _packageService.GetAllPackagesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }

        [HttpPost]
        public async Task<ActionResult> AddPackage([FromBody] Package package)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _packageService.AddPackageAsync(package);
            return CreatedAtAction(nameof(GetPackage), new { id = package.Id }, package);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePackage(int id, [FromBody] Package package)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _packageService.UpdatePackageAsync(package);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePackage(int id)
        {
            await _packageService.DeletePackageAsync(id);
            return NoContent();
        }
    }
}
