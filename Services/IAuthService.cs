namespace OpportunitiesAPI.Services;

public interface IAuthService
{
    string? GenerateToken(string username, string password);
}