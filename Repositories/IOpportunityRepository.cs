using OpportunitiesAPI.DTOs;
using OpportunitiesAPI.Models;

namespace OpportunitiesAPI.Repositories;

public interface IOpportunityRepository
{
    Task<(IEnumerable<Opportunity> items, int totalCount)> GetAllAsync(OpportunityFilterDto filter);
    Task<Opportunity?> GetByIdAsync(int id);
    Task<Opportunity> AddAsync(Opportunity opportunity);
    Task<Opportunity?> UpdateAsync(int id, Opportunity opportunity);
    Task<bool> DeleteAsync(int id);
}