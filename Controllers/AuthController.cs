using Microsoft.AspNetCore.Mvc;
using RemindMeApi.Data;
using RemindMeApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace RemindMeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromBody] User request)
    {
        if (_context.Users.Any(u => u.Email == request.Email))
        {
            return BadRequest(new { message = "Email already exists" });
        }

        var user = new User
        {
            Username = request.Username,
            Email = request.Email,
            PasswordHash = HashPassword(request.PasswordHash)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(new { message = "User registered successfully" });
    }

    private string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] User request)
    {
        var hashPassword = HashPassword(request.PasswordHash);
        var user = _context.Users.FirstOrDefault(u => u.Username == request.Username && u.PasswordHash == hashPassword);
        if (user == null)
        {
            return Unauthorized(new { message = "Invalid email or password" });
        }

            // Fake JWT (bạn sẽ dùng JWT thực tế sau)
        var token = "jwt-remindme-" + user.Username;

        return Ok(new { message = "Login successful", token });
    }

}
