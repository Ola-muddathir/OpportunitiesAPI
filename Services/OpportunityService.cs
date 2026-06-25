using OpportunitiesAPI.DTOs;
using OpportunitiesAPI.Models;
using OpportunitiesAPI.Repositories;

namespace OpportunitiesAPI.Services;

public class OpportunityService : IOpportunityService
{
    private readonly IOpportunityRepository _repo;

    public OpportunityService(IOpportunityRepository repo)
    {
        _repo = repo;
    }

    public Task<(IEnumerable<Opportunity> items, int totalCount)> GetAllAsync(OpportunityFilterDto filter) =>
        _repo.GetAllAsync(filter);

    public Task<Opportunity?> GetByIdAsync(int id) =>
        _repo.GetByIdAsync(id);

    public async Task<Opportunity> CreateAsync(OpportunityCreateDto dto)
    {
        var opportunity = new Opportunity
        {
            Title = dto.Title,
            Description = dto.Description,
            Type = dto.Type,
            Country = dto.Country,
            Deadline = dto.Deadline,
            IsFullyFunded = dto.IsFullyFunded,
            CreatedAt = DateTime.UtcNow
        };
        return await _repo.AddAsync(opportunity);
    }

    public async Task<Opportunity?> UpdateAsync(int id, OpportunityCreateDto dto)
    {
        var updated = new Opportunity
        {
            Title = dto.Title,
            Description = dto.Description,
            Type = dto.Type,
            Country = dto.Country,
            Deadline = dto.Deadline,
            IsFullyFunded = dto.IsFullyFunded
        };
        return await _repo.UpdateAsync(id, updated);
    }

    public Task<bool> DeleteAsync(int id) =>
        _repo.DeleteAsync(id);
}