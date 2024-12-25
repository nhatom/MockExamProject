using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using System.Data.Entity;


namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExamController : Controller
    {
        private readonly DataContext _dataContext;
        public ExamController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var listOfExam = (from a in _dataContext.EXAMS
                              join b in _dataContext.SUBJECT
                              on a.SubjectId equals b.SubjectId
                              orderby a.ExamId
                              select new ExamViewModel()
                              {
                                  ExamId = a.ExamId,
                                  ExamName = a.ExamName,
                                  CreatedBy = a.CreatedBy,
                                  Time = a.Time,
                                  SubjectId = a.SubjectId,
                                  NumberOfQuestion = a.NumberOfQuestion,
                                  SubjectName = b.SubjectName
                              }).ToList();

            return View("Index", listOfExam);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sb = _dataContext.EXAMS.Where(x => x.ExamId == id).ToList();
            Exam mn = sb.FirstOrDefault();
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var dl = _dataContext.EXAMS.Where(x => x.SubjectId == id).ToList();
            Exam deleSubject = dl.FirstOrDefault();
            if (deleSubject == null)
            {
                return NotFound();
            }
            _dataContext.EXAMS.Remove(deleSubject);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var subjectList = (from
                            b in _dataContext.SUBJECT
                               select new SelectListItem()
                               {
                                   Text = b.SubjectName,
                                   Value = b.SubjectId.ToString(),
                               }).ToList();
            subjectList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = "0"
            });
            ViewBag.subjectList = subjectList;

            var sb = _dataContext.EXAMS.Where(x => x.ExamId == id).ToList();
            Exam mn = sb.FirstOrDefault();
            if (mn == null)
            {
                return NotFound();
            }


            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Exam ex)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    _dataContext.EXAMS.Update(ex);
                    _dataContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(ex);
        }

        public IActionResult Create()
        {
            var subjectList = (from
                             b in _dataContext.SUBJECT
                               select new SelectListItem()
                               {
                                   Text = b.SubjectName,
                                   Value = b.SubjectId.ToString(),
                               }).ToList();
            subjectList.Insert(0, new SelectListItem()
            {
                Text = "---Select---",
                Value = "0"
            });
            ViewBag.subjectList = subjectList;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exam mn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dataContext.EXAMS.Add(mn);
                    _dataContext.SaveChanges();
                    return RedirectToAction("Index",mn);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(mn);
        }

        public IActionResult Setting(int id)
        {
			if (id == null || id == 0)
			{
				return NotFound();
			}
			var sb = _dataContext.EXAMS.Where(x => x.ExamId == id).ToList();
			Exam mn = sb.FirstOrDefault();
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);

			
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Setting(int id, int chapter1,int chapter2, int chapter3, int chapter4, int chapter5, int chapter6, int chapter7, int chapter8)
        {
			var ex = _dataContext.EXAMS.Where(x => x.SubjectId == id).ToList();
			Exam mn = ex.FirstOrDefault();
			if ((chapter1 + chapter2 + chapter3 + chapter4 + chapter5 + chapter6 + chapter7 + chapter8)!= mn.NumberOfQuestion)
                return NotFound();
            else
            {
                //var c1 = _dataContext.QUESTIONS.Where(a => a.SubjectId == id);
            }    
            return View("Index");
        }
    }
}
