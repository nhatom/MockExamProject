using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Areas.Admin.Models
{
	[Table("USERS", Schema = "ORACLE")]
	public class User
	{
		[Key]

		[Column("USERID")]
		public int UserID { get; set; }

		[Column("USERNAME")]
		public string? Username { get; set; }

		[Column("PASSWORD")]
		public string? Password { get; set; }

		[Column("FULLNAME")]
		public string? FullName { get; set; }

		[Column("ROLE")]
		public string? Role { get; set; }

		[Column("EMAIL")]
		public string? Email { get; set; }
	}
}