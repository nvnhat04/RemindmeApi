using Microsoft.AspNetCore.Mvc;
using RemindMeApi.Data;
using RemindMeApi.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace RemindMeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("profile")]

    public async Task<IActionResult> GetProfile([FromHeader(Name = "Authorization")] string? token)
    {
        if (string.IsNullOrEmpty(token) || !token.StartsWith("Bearer jwt-remindme-"))
        {
            return Unauthorized(new { message = "Invalid or missing token" });
        }

        // Tách username từ fake token
        var username = token.Replace("Bearer jwt-remindme-", "");

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        if (user == null)
        {
            return NotFound(new { message = "User not found" });
        }

        return Ok(new
        {
            message = "User profile fetched successfully",
            user = new
            {
                user.Id,
                user.Username,
                user.Email
            }
        });
    }


    }
