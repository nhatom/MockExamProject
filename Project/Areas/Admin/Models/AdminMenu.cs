using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.Core.Objects.DataClasses;

namespace Project.Areas.Admin.Models
{
    [Table("ADMINMENU",Schema = "ORACLE")]
    public class AdminMenu
    {
        [Key]
        [Column("ADMINMENUID")]
        public long AdminMenuID { get; set; }
        [Column("ITEMNAME")]
        public string? ItemName { get; set; }
        [Column("ITEMLEVEL")]
        public int? ItemLevel { get; set; }
        [Column("PARENTLEVEL")]
        public int? ParentLevel { get; set; }
        [Column("ITEMORDER")]
        public int? ItemOrder { get; set; }
        [Column("ISACTIVE")]
        public int? IsActive { get; set; }
        [Column("ITEMTARGET")]
        public string? ItemTarget { get; set; }
        [Column("AREANAME")]
        public string? AreaName { get; set; }
        [Column("CONTROLLERNAME")]
        public string? ControllerName { get; set; }
        [Column("ACTIONNAME")]
        public string? ActionName { get; set; }
        [Column("ICON")]
        public string? Icon { get; set; }
        [Column("IDNAME")]
        public string? IdName { get; set; }
    }
}
