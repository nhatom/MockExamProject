using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Components
{
    [ViewComponent(Name = "Exam")]
    public class ExamComponent : ViewComponent
    {
        private DataContext _context;
        public ExamComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var sql = "SELECT * FROM (SELECT * FROM EXAMS ORDER BY ExamId DESC) WHERE ROWNUM <= 6";
            var listofExam = await _context.EXAMS.FromSqlRaw(sql).ToListAsync();
            return View("Default", listofExam);

        }
    }
}
