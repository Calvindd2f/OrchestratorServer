// IActivityService.cs
using OrchestratorServer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchestratorServer.Services
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetAllActivitiesAsync();
        Task<Activity> GetActivityByIdAsync(int id);
        Task AddActivityAsync(Activity activity);
        Task UpdateActivityAsync(Activity activity);
        Task DeleteActivityAsync(int id);
    }
}
