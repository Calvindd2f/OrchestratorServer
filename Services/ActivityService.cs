// ActivityService.cs
using OrchestratorServer.Models;
using OrchestratorServer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchestratorServer.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task<IEnumerable<Activity>> GetAllActivitiesAsync()
        {
            return await _activityRepository.GetAllAsync();
        }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await _activityRepository.GetByIdAsync(id);
        }

        public async Task AddActivityAsync(Activity activity)
        {
            await _activityRepository.AddAsync(activity);
        }

        public async Task UpdateActivityAsync(Activity activity)
        {
            await _activityRepository.UpdateAsync(activity);
        }

        public async Task DeleteActivityAsync(int id)
        {
            await _activityRepository.DeleteAsync(id);
        }
    }
}
