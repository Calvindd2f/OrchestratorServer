// ConditionRepository.cs
using OrchestratorServer.Data;
using OrchestratorServer.Models;

namespace OrchestratorServer.Repositories
{
    public class ConditionRepository : Repository<Condition>, IConditionRepository
    {
        public ConditionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
