using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{

    [Table("SUBJECT", Schema = "ORACLE")]
    public class Subject

    {
        [Key]
        [Column("SUBJECTID")]
        public int SubjectId { get; set; }

        [Column("SUBJECTNAME")]
        public string? SubjectName { get; set; }

        [Column("DESCRIPTION")]
        public string? Description { get; set; }

        
    }
}
