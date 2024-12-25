using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using Project.Models;
using Project.Utilities;
using System.Collections;
using System.Data.Entity;
using System.Net.WebSockets;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
	
    public class MenuController : Controller
    {
		private readonly DataContext _dataContext;
		public String conString = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=ORACLE;Password=161199;";
		
        
        public MenuController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            var sql = "SELECT * FROM menu ORDER BY menu.MenuId";
            var listofMenu = _dataContext.MENU.FromSqlRaw(sql).ToList();
			
            return View(listofMenu);
			
        }
	
		public IActionResult Delete(int? id)
		{
			var query = "delete from menu where menuid =" + id;
			 String conString = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=ORACLE;Password=161199;";
			var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(conString);
			connection.Open();
			var sourQuery = connection.CreateCommand();
			sourQuery.CommandText = query;
			sourQuery.ExecuteNonQuery();
			//var reader = sourQuery.ExecuteReader();
			connection.Close();
            var sql = "SELECT * FROM menu ORDER BY menu.MenuId";
            var listofMenu = _dataContext.MENU.FromSqlRaw(sql).ToList();
            return View("Index",listofMenu);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
            var sql = "SELECT * FROM menu ";
            var mn = _dataContext.MENU.FromSqlRaw(sql).ToList();
            return RedirectToAction("Index",mn);
		}

		public IActionResult Edit(int? id)
		{
			if (id == null)
				return NotFound();
			var sql = "SELECT * FROM menu where menu.MenuId ="+id;
			var mn = _dataContext.MENU.FromSqlRaw(sql).ToList();
			return View(mn);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Menu mn)
		{
			if(ModelState.IsValid)
			{
				var query = "update menu mn set mn.MenuName = '"+mn.MenuName+ "' where mn.MenuId = "+mn.MenuId;
				String conString = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=ORACLE;Password=161199;";
				var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(conString);
				connection.Open();
				var sourQuery = connection.CreateCommand();
				sourQuery.CommandText = query;
				sourQuery.ExecuteNonQuery();
				//var reader = sourQuery.ExecuteReader();
				connection.Close();
			}
			return View(mn);
		}

		public IActionResult Create()
		{
            var parentList = (from
                             b in _dataContext.MENU
                               select new SelectListItem()
                               {
                                   Text = b.MenuName,
                                   Value = b.MenuId.ToString(),
                               }).ToList();
            parentList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = "0"
            });
            ViewBag.parentList = parentList;

            var menuOrderList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Vị trí 1", Value = "1" },
                new SelectListItem { Text = "Vị trí 2", Value = "2" },
                new SelectListItem { Text = "Vị trí 3", Value = "3" },
                new SelectListItem { Text = "Vị trí 4", Value = "4" },
                new SelectListItem { Text = "Vị trí 5", Value = "5" },
                new SelectListItem { Text = "Vị trí 6", Value = "6" },
                new SelectListItem { Text = "Vị trí 7", Value = "7" },
                new SelectListItem { Text = "Vị trí 8", Value = "8" },
            };
            ViewBag.MenuOrderList = menuOrderList;
            return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Menu mn)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_dataContext.MENU.Add(mn);
					_dataContext.SaveChanges();
					return RedirectToAction("Index");

				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return View(mn);
		}

	}
}
