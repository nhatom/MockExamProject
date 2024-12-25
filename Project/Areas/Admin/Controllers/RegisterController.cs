using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Areas.Admin.Models;
using Project.Models;
using Project.Utilities;
using System.Data.Entity;

namespace Project.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class RegisterController : Controller
	{
		private readonly DataContext _context;
		public RegisterController(DataContext context)
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
				Functions._MessageEmail = "Invalid data!";
				return View(user);
			}

			var check = _context.USERS.Where(m => m.Email == user.Email).ToList();
			if (check.Count > 0)
			{
				Functions._MessageEmail = "Duplicate Email!";
				return RedirectToAction("Index", "Register");
			}

			Functions._MessageEmail = string.Empty;
			user.Password = Functions.MD5Password(user.Password);

			try
			{
				if (ModelState.IsValid)
				{
					_context.USERS.Add(user);
					_context.SaveChanges();
					return RedirectToAction("Index", "Login");
				}
				else
				{
					Functions._MessageEmail = "Invalid input data!";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
			return View(user);
		}

	}
}