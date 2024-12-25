using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Utilities;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/exam-{slug}-{id:long}.html", Name = "DetailsExam")]

        public IActionResult DetailsExam(long? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var listQues = (from a in _context.examQuestions
                            join
                            b in _context.QUESTIONS on a.QuestionId
                            equals b.QuestionId where a.ExamId == id
                            select
                            new QuesOfExam
                            {
                                ExamId = a.ExamId,
                                QuestionId = b.QuestionId,
                                QuestionText = b.QuestionText,
                                OptionA = b.OptionA,
                                OptionB = b.OptionB,
                                OptionC = b.OptionC,
                                OptionD = b.OptionD,
                                CorrectOption = b.CorrectOption,
                            }).ToList();

            var exam = _context.EXAMS.Where(x => x.ExamId == id).ToList();
            Exam mn = exam.FirstOrDefault();

            if (exam == null)
            {
                return NotFound();
            }
            ViewBag.ExamId = id;
            return View(listQues);
        }

        public IActionResult Logout()
        {
            Functions._UserID = 0;
            Functions._Username = string.Empty;
            Functions._Email = string.Empty;
            Functions._Message = string.Empty;
            Functions._MessageEmail = string.Empty;

            return RedirectToAction("Index", "Home");
        }
    }
}
