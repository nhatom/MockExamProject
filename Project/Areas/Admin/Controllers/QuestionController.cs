using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Project.Models;
using Project.Utilities;
using System.Data.Entity;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;


namespace Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QuestionController : Controller
    {
        private readonly DataContext _dataContext;
        public QuestionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "Login");
            var listOfQuestion = _dataContext.QUESTIONS.OrderByDescending(x => x.QuestionId).ToList();
            return View("Index", listOfQuestion);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sb = _dataContext.QUESTIONS.Where(x => x.QuestionId == id).ToList();
            Question mn = sb.FirstOrDefault();
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);

        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var dl = _dataContext.QUESTIONS.Where(x => x.QuestionId == id).ToList();
            Question deleQUESTIONS = dl.FirstOrDefault();
            if (deleQUESTIONS == null)
            {
                return NotFound();
            }
            _dataContext.QUESTIONS.Remove(deleQUESTIONS);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var sb = _dataContext.QUESTIONS.Where(x => x.QuestionId == id).ToList();
            Question mn = sb.FirstOrDefault();
            if (mn == null)
            {
                return NotFound();
            }
            var answerList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Đáp án A", Value = "A" },
                new SelectListItem { Text = "Đáp án B", Value = "B" },
                new SelectListItem { Text = "Đáp án C", Value = "C" },
                new SelectListItem { Text = "Đáp án D", Value = "D" },
            };
            ViewBag.AnswerList = answerList;

            var chapterList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Chương I", Value = "1" },
                new SelectListItem { Text = "Đáp án II", Value = "2" },
                new SelectListItem { Text = "Đáp án III", Value = "3" },
                new SelectListItem { Text = "Đáp án IV", Value = "4" },
                new SelectListItem { Text = "Đáp án V", Value = "5" },
                new SelectListItem { Text = "Đáp án VI", Value = "6" },
                new SelectListItem { Text = "Đáp án VII", Value = "7" },
                new SelectListItem { Text = "Đáp án VIII", Value = "8" },
            };
            ViewBag.ChapterList = chapterList;

            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Question mn)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    _dataContext.QUESTIONS.Update(mn);
                    _dataContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(mn);
        }

        public IActionResult Create()
        {
            var answerList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Đáp án A", Value = "A" },
                new SelectListItem { Text = "Đáp án B", Value = "B" },
                new SelectListItem { Text = "Đáp án C", Value = "C" },
                new SelectListItem { Text = "Đáp án D", Value = "D" },
            };
            ViewBag.AnswerList = answerList;

            var chapterList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Chương I", Value = "1" },
                new SelectListItem { Text = "Chương II", Value = "2" },
                new SelectListItem { Text = "Chương III", Value = "3" },
                new SelectListItem { Text = "Chương IV", Value = "4" },
                new SelectListItem { Text = "Chương V", Value = "5" },
                new SelectListItem { Text = "Chương VI", Value = "6" },
                new SelectListItem { Text = "Chương VII", Value = "7" },
                new SelectListItem { Text = "Chương VIII", Value = "8" },
            };
            ViewBag.ChapterList = chapterList;

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
        public IActionResult Create(Question mn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _dataContext.QUESTIONS.Add(mn);
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

        public IActionResult CreateMany()
        {
            var chapterList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Chương I", Value = "1" },
                new SelectListItem { Text = "Chương II", Value = "2" },
                new SelectListItem { Text = "Chương III", Value = "3" },
                new SelectListItem { Text = "Chương IV", Value = "4" },
                new SelectListItem { Text = "Chương V", Value = "5" },
                new SelectListItem { Text = "Chương VI", Value = "6" },
                new SelectListItem { Text = "Chương VII", Value = "7" },
                new SelectListItem { Text = "Chương VIII", Value = "8" },
            };
            chapterList.Insert(0, new SelectListItem()
                {
                Text = "---Select---",
                Value = "0"
            });
            ViewBag.chapterList = chapterList;
            // Tạo view bag các chapter

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
            // tạo viewbag các subject
            return View();
        }
        [HttpPost]

        public IActionResult CreateMany(String inputFile, String ChapterId, String SubjectId)
        {
            try
            {
                String inputFile1 = @"D:\test.txt";
                
                //@"D:\test.txt";
                List<Question> listQuestion = new List<Question>();

                List<Question> questions = new List<Question>();

                if (System.IO.File.Exists(inputFile1))
                {
                    StreamReader reader = new StreamReader(inputFile1);
                    String? text = reader.ReadToEnd();
                    List<string> ques = new List<string>();
                    var matches = Regex.Matches(text, @"(Câu hỏi.*?)(?=Câu hỏi|$)", RegexOptions.Singleline);

                    foreach (Match match in matches)
                    {
                        var questext = Regex.Match(match.Value, @"Câu hỏi\s*:\s*(.*?)(?=\s*A\.)").Groups[1].Value.Trim();
                        var optA = Regex.Match(match.Value, @"A\.\s*(.*?)(?=\s*B\.)").Groups[1].Value.Trim();
                        var optB = Regex.Match(match.Value, @"B\.\s*(.*?)(?=\s*C\.)").Groups[1].Value.Trim();
                        var optC = Regex.Match(match.Value, @"C\.\s*(.*?)(?=\s*D\.)").Groups[1].Value.Trim();
                        var optD = Regex.Match(match.Value, @"D\.\s*(.*?)(?=\s*Đáp án)").Groups[1].Value.Trim();
                        var corOpt = Regex.Match(match.Value, @"Đáp án\s*:\s*(.*)").Groups[1].Value.Trim();

                        questions.Add(new Question
                        {
                            QuestionText = questext,
                            OptionA = optA,
                            OptionB = optB,
                            OptionC = optC,
                            OptionD = optD,
                            CorrectOption = corOpt,
                            Chapter = ChapterId,
                            SubjectId = SubjectId,
                        });
                    }

                    reader.Close();
                }
                else
                {                    
                    return StatusCode(404, "File không tồn tại");
                }           
                _dataContext.QUESTIONS.AddRange(questions);
                _dataContext.SaveChanges();
                return View("ResultAfterInsertMany", questions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error: " + ex.Message);
            }
            var listOfQuestion = _dataContext.QUESTIONS.OrderByDescending(x => x.QuestionId).ToList();
            return View("Index", listOfQuestion);
             
        }

        public IActionResult ResultAfterInsertMany()
        {
            return View();
        }






    }
}
