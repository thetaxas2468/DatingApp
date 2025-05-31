using DatingAppBackend.Data;
using DatingAppBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppBackend.Controllers
{
  [Authorize]
  public class UsersController : BaseApiController
  {
    private readonly DataContext _context;
    public UsersController(DataContext context)
    {
      _context = context;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
      try
      {
        var users = await _context.Users.ToListAsync();
        if (users == null || users.Count == 0)
        {
          return NotFound("No users found.");
        }

        return Ok(users);
      }
      catch (Exception ex)
      {
        return StatusCode(500, "An error occurred while retrieving users." + ex.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
      if (id <= 0)
      {
        return BadRequest("Invalid user ID.");
      }

      try
      {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
          return NotFound($"User with ID {id} not found.");
        }

        return Ok(user);
      }
      catch (Exception ex)
      {
        return StatusCode(500, "An error occurred while retrieving the user." + ex.Message);
      }
    }
  }
}
