using OrchestratorServer.Models;
using System.Threading.Tasks;

namespace OrchestratorServer.Services
{
    public interface IWorkflowExecutionService
    {
        Task ExecuteWorkflowAsync(int packageId);
        Task UpdateWorkflowStatusAsync(int packageId, string status);
        Task PauseWorkflowForInputAsync(int packageId, string formData);
    }
}
