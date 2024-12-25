using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    [Table("QUESTIONS", Schema = "ORACLE")]
    public class Question

    {
        [Key]
        [Column("QUESTIONID")]
        public int QuestionId { get; set; }

        [Column("QUESTIONTEXT")]
        public string? QuestionText { get; set; }

        [Column("OPTIONA")]
        public string? OptionA { get; set; }
        
        [Column("OPTIONB")]
        public string? OptionB { get; set; }
        [Column("OPTIONC")]
        public string? OptionC { get; set; }
        [Column("OPTIOND")]
        public string? OptionD { get; set; }
        [Column("CORRECTOPTION")]
        public string? CorrectOption { get; set; }
        [Column("CHAPTER")]
        public string? Chapter { get; set; }

        [Column("SUBJECTID")]
        public string? SubjectId { get; set; }
    }
}
