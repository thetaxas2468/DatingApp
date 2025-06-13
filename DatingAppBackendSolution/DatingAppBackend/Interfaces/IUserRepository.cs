using DatingAppBackend.DTOs;
using DatingAppBackend.Models;

namespace DatingAppBackend.Interfaces
{
  public interface IUserRepository
  {
    void Update(AppUser user);
    Task<bool> SaveAllAsync();
    Task<IEnumerable<AppUser>> GetUsersAsync();
    Task<AppUser?> GetUserByIdAsync(int id);
    Task<AppUser?> GetUserByUsernameAsync(string username);
    Task<IEnumerable<MemberDto>> GetMembersAsync();
    Task<MemberDto?> GetMemberByUsernameAsync(string username);
    Task<MemberDto?> GetMemberByIdAsync(int id);
  }
}
