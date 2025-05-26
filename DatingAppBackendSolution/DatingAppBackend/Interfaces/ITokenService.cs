using DatingAppBackend.Models;

namespace DatingAppBackend.Interfaces
{
  public interface ITokenService
  {
    string CreateToken(AppUser user);
    //Task<string> CreateRefreshTokenAsync(AppUser user);
    //Task<bool> ValidateRefreshTokenAsync(string token, AppUser user);
    //Task RevokeRefreshTokenAsync(string token, AppUser user);
    //Task<AppUser> GetUserFromRefreshTokenAsync(string token);
  }
}
