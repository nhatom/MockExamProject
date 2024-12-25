using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Project.Models;
using Project.Utilities;
using System.Data.Entity;
using System.Text.RegularExpressions;
using Project.Areas.Admin.Models;

namespace Project.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly DataContext _context;
		public UserController(DataContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			if (!Functions.IsLogin())
				return RedirectToAction("Index", "Login");
			var listOfUser = _context.USERS.Where(x => x.Role == "user").OrderByDescending(x => x.UserID).ToList();


			return View("Index", listOfUser);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var sb = _context.USERS.Where(x => x.UserID == id).ToList();
			User mn = sb.FirstOrDefault();
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);

		}
		[HttpPost]
		public IActionResult Delete(int id)
		{
			var dl = _context.USERS.Where(x => x.UserID == id).ToList();
			User deleUser = dl.FirstOrDefault();
			if (deleUser == null)
			{
				return NotFound();
			}
			_context.USERS.Remove(deleUser);
			_context.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}