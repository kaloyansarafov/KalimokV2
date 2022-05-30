using KalimokV2.Data;
using KalimokV2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KalimokV2.Controllers;

public class UserController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly ApplicationDbContext _context;
    
    public UserController(UserManager<User> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }
    // GET
    public IActionResult Search(string? searchString)
    {
        var users = _context.Users.ToList();

        if (!String.IsNullOrEmpty(searchString))
        {
            users = users.Where(s => s.UserName.Contains(searchString)).ToList();
        }

        return View(users);
    }

    public IActionResult Details(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var user = _context.Users
            .Include(a => a.Posts)
            .Include(a => a.Comments)!
            .ThenInclude(c => c.Post)
            .FirstOrDefaultAsync(x => x.Id == id).Result;

        return View(user);
    }
}