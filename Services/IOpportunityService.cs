using OpportunitiesAPI.DTOs;
using OpportunitiesAPI.Models;

namespace OpportunitiesAPI.Services;

public interface IOpportunityService
{
    Task<(IEnumerable<Opportunity> items, int totalCount)> GetAllAsync(OpportunityFilterDto filter);
    Task<Opportunity?> GetByIdAsync(int id);
    Task<Opportunity> CreateAsync(OpportunityCreateDto dto);
    Task<Opportunity?> UpdateAsync(int id, OpportunityCreateDto dto);
    Task<bool> DeleteAsync(int id);
}