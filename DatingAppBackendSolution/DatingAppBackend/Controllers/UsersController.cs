using AutoMapper;
using DatingAppBackend.Data;
using DatingAppBackend.DTOs;
using DatingAppBackend.Interfaces;
using DatingAppBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAppBackend.Controllers
{
  [Authorize]
  public class UsersController : BaseApiController
  {
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
      try
      {
        var users = await _userRepository.GetMembersAsync();
        if (users == null || users.Count() == 0)
        {
          return NotFound("No users found.");
        }
        // Optionally map to a DTO if needed

        return Ok(users);
      }
      catch (Exception ex)
      {
        return StatusCode(500, "An error occurred while retrieving users." + ex.Message);
      }
    }

    [HttpGet("id/{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id)
    {
      if (id <= 0)
      {
        return BadRequest("Invalid user ID.");
      }

      try
      {
        var user = await _userRepository.GetMemberByIdAsync(id);
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
    [HttpGet("{username}")]
    public async Task<ActionResult<AppUser>> GetUserByUsername(string username)
    {
      if (string.IsNullOrWhiteSpace(username))
      {
        return BadRequest("Username must not be empty.");
      }
      try
      {
        var user = await _userRepository.GetMemberByUsernameAsync(username);
        if (user == null)
        {
          return NotFound($"User with username {username} not found.");
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
