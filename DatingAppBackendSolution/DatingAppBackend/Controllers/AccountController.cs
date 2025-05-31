using DatingAppBackend.Data;
using DatingAppBackend.DTOs;
using DatingAppBackend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace DatingAppBackend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController(DataContext context, ITokenService tokenService) : ControllerBase
{
  [HttpPost("register")]
  public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
  {
    if (string.IsNullOrWhiteSpace(registerDto.Username) || string.IsNullOrWhiteSpace(registerDto.Password))
    {
      return BadRequest("Username and password must not be empty.");
    }

    var username = registerDto.Username.Trim().ToLower();

    if (await UserExists(username))
    {
      return BadRequest("Username is already taken.");
    }

    try
    {
      using var hmac = new HMACSHA512();
      var user = new AppUser
      {
        UserName = username,
        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        PasswordSalt = hmac.Key
      };

      context.Users.Add(user);
      await context.SaveChangesAsync();

      return Ok(new UserDto
      {
        UserName = user.UserName,
        Token = tokenService.CreateToken(user)
      });
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [HttpPost("login")]
  public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
  {
    if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
    {
      return BadRequest("Username and password must not be empty.");
    }

    var username = loginDto.Username.Trim().ToLower();

    try
    {
      var user = await context.Users
          .FirstOrDefaultAsync(x => x.UserName == username);

      if (user == null)
      {
        return Unauthorized("Invalid username or password.");
      }

      using var hmac = new HMACSHA512(user.PasswordSalt);
      var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

      if (!computedHash.SequenceEqual(user.PasswordHash))
      {
        return Unauthorized("Invalid username or password.");
      }

      return Ok(new UserDto
      {
        UserName = user.UserName,
        Token = tokenService.CreateToken(user)
      });
    }
    catch (Exception ex)
    {
      return StatusCode(500, $"Internal server error: {ex.Message}");
    }
  }

  [AllowAnonymous]
  [HttpGet("Internalerror")]
  public ActionResult<string> InternalError()
  {
    return StatusCode(500, $"Internal server error");
  }

  private async Task<bool> UserExists(string username)
  {
    return await context.Users.AnyAsync(x => x.UserName == username);
  }
}
