using Microsoft.EntityFrameworkCore;
using OpportunitiesAPI.Data;
using OpportunitiesAPI.DTOs;
using OpportunitiesAPI.Models;

namespace OpportunitiesAPI.Repositories;

public class OpportunityRepository : IOpportunityRepository
{
    private readonly AppDbContext _context;

    public OpportunityRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<(IEnumerable<Opportunity> items, int totalCount)> GetAllAsync(OpportunityFilterDto filter)
    {
        var query = _context.Opportunities.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Keyword))
            query = query.Where(o => o.Title.Contains(filter.Keyword)
                                  || o.Description.Contains(filter.Keyword));

        if (!string.IsNullOrWhiteSpace(filter.Type))
            query = query.Where(o => o.Type == filter.Type);

        if (!string.IsNullOrWhiteSpace(filter.Country))
            query = query.Where(o => o.Country == filter.Country);

        if (filter.IsFullyFunded.HasValue)
            query = query.Where(o => o.IsFullyFunded == filter.IsFullyFunded.Value);

        var total = await query.CountAsync();
        var items = await query
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ToListAsync();

        return (items, total);
    }

    public async Task<Opportunity?> GetByIdAsync(int id) =>
        await _context.Opportunities.FindAsync(id);

    public async Task<Opportunity> AddAsync(Opportunity opportunity)
    {
        _context.Opportunities.Add(opportunity);
        await _context.SaveChangesAsync();
        return opportunity;
    }

    public async Task<Opportunity?> UpdateAsync(int id, Opportunity updated)
    {
        var existing = await _context.Opportunities.FindAsync(id);
        if (existing == null) return null;

        existing.Title = updated.Title;
        existing.Description = updated.Description;
        existing.Type = updated.Type;
        existing.Country = updated.Country;
        existing.Deadline = updated.Deadline;
        existing.IsFullyFunded = updated.IsFullyFunded;

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var opportunity = await _context.Opportunities.FindAsync(id);
        if (opportunity == null) return false;

        _context.Opportunities.Remove(opportunity);
        await _context.SaveChangesAsync();
        return true;
    }
}