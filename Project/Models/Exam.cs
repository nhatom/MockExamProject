using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    [Table("EXAMS", Schema = "ORACLE")]
    public class Exam

    {
        [Key]
        [Column("EXAMID")]
        public int ExamId { get; set; }

        [Column("EXAMNAME")]
        [Required(ErrorMessage = "Vui lòng nhập tên bài thi!")]
        public string? ExamName { get; set; }

        [Column("CREATEDBY")]
        public int? CreatedBy { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn môn học!")]
        [Column("SUBJECTID")]
        public int? SubjectId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập thời gian làm bài!")]
        [Column("TIME")]
        public int? Time { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số lượng câu hỏi!")]
        [Column("NUMBEROFQUESTIONS")]
        public int? NumberOfQuestion { get; set; }

    }
}
