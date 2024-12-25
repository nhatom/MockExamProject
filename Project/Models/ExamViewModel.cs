using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Keyless]
    public class ExamViewModel
    {
        [Column("EXAMID")]
        public int ExamId { get; set; }

        [Column("EXAMNAME")]
        public string? ExamName { get; set; }

        [Column("CREATEBY")]
        public int? CreatedBy { get; set; }

        [Column("SUBJECTID")]
        public int? SubjectId { get; set; }
        [Column("TIME")]
        public int? Time { get; set; }
        [Column("SUBJECTNAME")]
        public string? SubjectName { get; set; }
        [Column("NUMBEROFQUESTIONS")]
        public int? NumberOfQuestion { get; set; }

    }
}
