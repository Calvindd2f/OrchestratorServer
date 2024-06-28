// WorkflowService.cs
using OrchestratorServer.Models;
using OrchestratorServer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchestratorServer.Services
{
    public class WorkflowService : IWorkflowService
    {
        private readonly IWorkflowRepository _workflowRepository;

        public WorkflowService(IWorkflowRepository workflowRepository)
        {
            _workflowRepository = workflowRepository;
        }

        public async Task<IEnumerable<Workflow>> GetAllWorkflowsAsync()
        {
            return await _workflowRepository.GetAllAsync();
        }

        public async Task<Workflow> GetWorkflowByIdAsync(int id)
        {
            return await _workflowRepository.GetByIdAsync(id);
        }

        public async Task AddWorkflowAsync(Workflow workflow)
        {
            await _workflowRepository.AddAsync(workflow);
        }

        public async Task UpdateWorkflowAsync(Workflow workflow)
        {
            await _workflowRepository.UpdateAsync(workflow);
        }

        public async Task DeleteWorkflowAsync(int id)
        {
            await _workflowRepository.DeleteAsync(id);
        }
    }
}
