// IConditionService.cs
using OrchestratorServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchestratorServer.Services
{
    public interface IConditionService
    {
        Task<IEnumerable<Condition>> GetAllConditionsAsync();
        Task<Condition> GetConditionByIdAsync(int id);
        Task AddConditionAsync(Condition condition);
        Task UpdateConditionAsync(Condition condition);
        Task DeleteConditionAsync(int id);
    }
}
