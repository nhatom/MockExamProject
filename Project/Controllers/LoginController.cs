using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Areas.Admin.Models;
using Project.Models;
using Project.Utilities;

namespace Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (user == null)
            {
                return NotFound();
            }

            string pw = Functions.MD5Password(user.Password);
            var check = _context.USERS.Where(m => (m.Email == user.Email) && (m.Password == pw) && (m.Role == "Student")).ToList();

            // Check if the list is empty
            if (!check.Any())
            {
                Functions._Message = "Invalid UserName or Password!";
                return RedirectToAction("Index", "Login");
            }

            User mn = check.First(); // Retrieve the first user from the list

            Functions._Message = string.Empty;
            Functions._UserID = mn.UserID;
            Functions._Username = string.IsNullOrEmpty(mn.Username) ? string.Empty : mn.Username;
            Functions._Email = string.IsNullOrEmpty(mn.Email) ? string.Empty : mn.Email;

            return RedirectToAction("Index", "Home");
        }
    }
}
