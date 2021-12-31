#nullable disable
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyingOnline.Helpers;
using StudyingOnline.Models;

namespace StudyingOnline.Controllers;
public class UserController : Controller
{
    private readonly StudyingOnlineContext _context;

    public UserController(StudyingOnlineContext context)
    {
        _context = context;
    }

    public IActionResult Denied()
    {
        return View();
    }

    // GET: User
    public async Task<IActionResult> Index()
    {
        return View(await _context.User.ToListAsync());
    }

    // GET: User/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.User
            .FirstOrDefaultAsync(m => m.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // GET: User/Create
    public IActionResult Create()
    {
        return View();
    }

    // GET: User/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: User/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([Bind("Id,Email,Password,Name,Phone,IsAdmin")] User user)
    {
        if (ModelState.IsValid)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HomeController.Index));
        }
        return View(user);
    }

    // GET: User/Login
    public IActionResult Login()
    {
        return View();
    }

    // POST: User/Login
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login([Bind("Email,Password")] Login user)
    {
        if (ModelState.IsValid)
        {
            var userDB = await _context.User
               .FirstOrDefaultAsync(m => m.Email == user.Email);
            if (userDB == null)
            {
                ModelState.AddModelError("", "The credentials are not valid!");
                return View(user);
            }

            if (BCrypt.Net.BCrypt.Verify(user.Password, userDB.Password))
            {
                var authClaims = new List<Claim>(){
                    new Claim(CustomClaimTypes.Id, userDB.Id.ToString()),
                    new Claim(CustomClaimTypes.Email, userDB.Email),
                    new Claim(CustomClaimTypes.Name, userDB.Name),
                    new Claim(CustomClaimTypes.Phone, userDB.Phone),
                    new Claim(CustomClaimTypes.Admin, userDB.IsAdmin.ToString()),
                };

                var authIdentity = new ClaimsIdentity(authClaims, "CookieAuth");

                var userPrincipal = new ClaimsPrincipal(new[] { authIdentity });

                await HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "The credentials are not valid!");
                return View(user);
            }
        }
        return View(user);
    }

    // GET: User/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.User.FindAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    // POST: User/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password,Name,Phone,IsAdmin")] User user)
    {
        if (id != user.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    // GET: User/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var user = await _context.User
            .FirstOrDefaultAsync(m => m.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // POST: User/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var user = await _context.User.FindAsync(id);
        _context.User.Remove(user);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool UserExists(int id)
    {
        return _context.User.Any(e => e.Id == id);
    }
}