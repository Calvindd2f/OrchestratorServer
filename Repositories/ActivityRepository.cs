// ActivityRepository.cs
using OrchestratorServer.Data;
using OrchestratorServer.Models;

namespace OrchestratorServer.Repositories
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(AppDbContext context) : base(context)
        {
        }
    }
}
