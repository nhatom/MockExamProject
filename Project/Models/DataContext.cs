using Microsoft.EntityFrameworkCore;
using Oracle.EntityFrameworkCore;
using Project.Areas.Admin.Models;

namespace Project.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Menu> MENU { get; set; }
        public DbSet<AdminMenu> AdminMenus { get; set; }

        public DbSet<Subject> SUBJECT { get; set; }

        public DbSet<Question>  QUESTIONS { get; set; }

        public DbSet<Exam> EXAMS { get; set;     }  

        public DbSet<User> USERS { get; set; }

        public DbSet<ExamQuestion> examQuestions { get; set; }

        public DbSet<QuesOfExam> quesOfExams { get; set; }

        public DbSet<Result> RESULTS { get; set; }
    }
}
