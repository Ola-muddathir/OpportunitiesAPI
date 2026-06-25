using Microsoft.EntityFrameworkCore;
using OpportunitiesAPI.Models;

namespace OpportunitiesAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Opportunity> Opportunities { get; set; }
}