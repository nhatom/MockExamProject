using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Table("RESULTS", Schema = "ORACLE")]
    public class Result
    {
        [Key]
        [Column("RESULTID")]
        public int ResultId { get; set; }

        [Column("EXAMID")]
        public int ExamId { get; set; }
        [Column("USERID")]
        public int? UserId { get; set; }
        [Column("SCORE")]
        public double Score { get; set; }
        [Column("SESSION")]
        public string? Session { get; set; }
    }
}
