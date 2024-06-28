// WorkflowRepository.cs
using OrchestratorServer.Data;
using OrchestratorServer.Models;

namespace OrchestratorServer.Repositories
{
    public class WorkflowRepository : Repository<Workflow>, IWorkflowRepository
    {
        public WorkflowRepository(AppDbContext context) : base(context)
        {
        }
    }
}
