namespace OpportunitiesAPI.DTOs;

public class OpportunityFilterDto
{
    public string? Keyword { get; set; }
    public string? Type { get; set; }
    public string? Country { get; set; }
    public bool? IsFullyFunded { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}