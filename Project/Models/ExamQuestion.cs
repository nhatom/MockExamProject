using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    [Table("EXAMQUESTIONS", Schema = "ORACLE")]
    [Keyless]
    public class ExamQuestion

    {
        
        [Column("EXAMID")]
        public int ExamId { get; set; }

        [Column("QUESTIONID")] 
        public int QuestionId { get; set; }
 

    }
}
