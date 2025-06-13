using AutoMapper;
using AutoMapper.QueryableExtensions;
using DatingAppBackend.Data;
using DatingAppBackend.DTOs;
using DatingAppBackend.Interfaces;
using DatingAppBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAppBackend.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public UserRepository(DataContext context,IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public void Update(AppUser user)
    {
      _context.Entry(user).State = EntityState.Modified;
    }
    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }
    public async Task<IEnumerable<AppUser>> GetUsersAsync()
    {
      return await _context.Users.Include(x=>x.Photos)
        .ToListAsync();
    }
    public async Task<AppUser?> GetUserByIdAsync(int id)
    {
      return await _context.Users.FindAsync(id);
    }
    public async Task<AppUser?> GetUserByUsernameAsync(string username)
    {
      return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
    }

    public async Task<IEnumerable<MemberDto>> GetMembersAsync()
    {
      return await _context.Users.ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
        .ToListAsync();
    }

    public async Task<MemberDto?> GetMemberByUsernameAsync(string username)
    {
      return await _context.Users
        .Where(x => x.UserName == username)
        .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
        .SingleOrDefaultAsync();
    }

    public async Task<MemberDto?> GetMemberByIdAsync(int id)
    {
      return await _context.Users
        .Where(x => x.Id == id)
        .ProjectTo<MemberDto>(_mapper.ConfigurationProvider)
        .SingleOrDefaultAsync();
    }
  }
}
