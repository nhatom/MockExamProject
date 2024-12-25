using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Project.Utilities;
using System.Data.Entity;

namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubjectController : Controller
    {
        private readonly DataContext _dataContext;
        public SubjectController(DataContext dataContext) {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            var listOfSubject = _dataContext.SUBJECT.OrderByDescending(x => x.SubjectId).ToList();
            
            return View("Index",listOfSubject);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sb = _dataContext.SUBJECT.Where(x => x.SubjectId == id).ToList();
			Subject mn = sb.FirstOrDefault();
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
            
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var dl = _dataContext.SUBJECT.Where(x => x.SubjectId == id).ToList();
			Subject deleSubject = dl.FirstOrDefault();
            if (deleSubject == null)
            {
                return NotFound();
            }
            _dataContext.SUBJECT.Remove(deleSubject);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

		public IActionResult Edit(int id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var sb = _dataContext.SUBJECT.Where(x=>x.SubjectId == id).ToList();
			Subject mn = sb.FirstOrDefault();            
            if (mn == null)
			{
				return NotFound();
			}
			
			
			return View(mn);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Subject mn)
		{
			if (ModelState.IsValid)
			{
				if (ModelState.IsValid)
				{
					_dataContext.SUBJECT.Update(mn);
					_dataContext.SaveChanges();
					return RedirectToAction("Index");
				}
			}
			return View(mn);
		}

		public IActionResult Create()
		{
			var mnList = (from m in _dataContext.SUBJECT
						  select new SelectListItem()
						  {
							  Text = m.SubjectName,
							  Value = m.SubjectId.ToString(),
						  }).ToList();			
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(Subject mn)
		{
			try
			{
                if (ModelState.IsValid)
                {
                    _dataContext.SUBJECT.Add(mn);
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
