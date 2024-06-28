// ConditionService.cs
using OrchestratorServer.Exceptions;
using OrchestratorServer.Models;
using OrchestratorServer.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrchestratorServer.Services
{
    public class ConditionService : IConditionService
    {
        private readonly IConditionRepository _conditionRepository;

        public ConditionService(IConditionRepository conditionRepository)
        {
            _conditionRepository = conditionRepository;
        }

        public async Task<IEnumerable<Condition>> GetAllConditionsAsync()
        {
            return await _conditionRepository.GetAllAsync();
        }

        public async Task<Condition> GetConditionByIdAsync(int id)
        {
            var condition = await _conditionRepository.GetByIdAsync(id);
            if (condition == null)
            {
                throw new NotFoundException($"Condition with id {id} not found.");
            }
            return condition;
        }

        public async Task AddConditionAsync(Condition condition)
        {
            try
            {
                await _conditionRepository.AddAsync(condition);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Error adding condition: {ex.Message}");
            }
        }

        public async Task UpdateConditionAsync(Condition condition)
        {
            var existingCondition = await GetConditionByIdAsync(condition.Id);
            if (existingCondition == null)
            {
                throw new NotFoundException($"Condition with id {condition.Id} not found.");
            }

            try
            {
                await _conditionRepository.UpdateAsync(condition);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Error updating condition: {ex.Message}");
            }
        }

        public async Task DeleteConditionAsync(int id)
        {
            var existingCondition = await GetConditionByIdAsync(id);
            if (existingCondition == null)
            {
                throw new NotFoundException($"Condition with id {id} not found.");
            }

            try
            {
                await _conditionRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                throw new ServiceException($"Error deleting condition: {ex.Message}");
            }
        }
    }
}
