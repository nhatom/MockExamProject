using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    [Table("MENU", Schema = "ORACLE")]
    public class Menu 
    {
        [Key]
        [Column("MENUID")]
        public int MenuId { get; set; }
        [Column("MENUNAME")] 
        public string? MenuName { get; set; }
        [Column("ISACTIVE")]
        public int? IsActive { get; set; }
        [Column("CONTROLLERNAME")]
        public string? ControllerName { get; set; }
        [Column("ACTIONNAME")]
        public string? ActionName { get; set; }
        [Column("LEVELS")]
        public int? Levels { get; set; }
        [Column("LINK")]
        public String? Link { get; set; }
        [Column("MENUORDER")]
        public int MenuOrder { get; set; }
        [Column("POSITION")]
        public int? Position { get; set; }
        [Column("PARENTID")]
        public int? ParentId { get; set; }

    }
}
