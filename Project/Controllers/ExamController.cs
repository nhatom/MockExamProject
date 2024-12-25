using Project.Models;
using Project.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Utilities;

namespace Project.Controllers
{
    public class ExamController : Controller
    {
        private readonly DataContext _context;
        public ExamController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnList = (from m in _context.SUBJECT
                          select new SelectListItem()
                          {
                              Text = m.SubjectName,
                              Value = m.SubjectId.ToString(),
                          }).ToList();
            ViewBag.mnList = mnList;

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Exam exams)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exams);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult CreateDetail(List<QuesOfExam> model,int ExamId)
        {
            if (ModelState.IsValid)
            {
                int totalQuestions = model.Count;
                int correctAnswers = 0;

                // Xử lý danh sách câu trả lời
                foreach (var question in model)
                {
                    int examIdIneed = question.ExamId;
                    if (question.UserAnswer == question.CorrectOption)
                    {
                        correctAnswers++;
                    }
                }

                // Tính tỷ lệ đúng
                double accuracy = (double)correctAnswers / totalQuestions ;
                if(Functions.IsLogin())
                {
                    
                    Result result = new Result();
                    result.UserId = Functions._UserID;
                    result.ExamId = ExamId;
                    result.Session = "Test";
                    result.Score = accuracy;
                    _context.RESULTS.Add(result);
                    _context.SaveChanges();
                }    


                // Truyền dữ liệu qua ViewBag
                
                ViewBag.TotalQuestions = totalQuestions;
                ViewBag.CorrectAnswers = correctAnswers;
                ViewBag.Accuracy = accuracy;

                return View("Result"); // Hiển thị View Result
            }
            else
            {
                return View("Index");
            }
        }

    }
}
