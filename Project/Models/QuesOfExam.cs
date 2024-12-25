using Microsoft.EntityFrameworkCore;

namespace Project.Models
{
    [Keyless]
    public class QuesOfExam 
    {
        public int ExamId { get; set; }

        public int QuestionId { get; set; }
        public string? QuestionText { get; set; }
        public string? OptionA { get; set; }

        public string? OptionB { get; set; }
        public string? OptionC { get; set; }
        public string? OptionD { get; set; }

        public string? CorrectOption { get; set; }

        public string? UserAnswer { get; set; }


    }
}
