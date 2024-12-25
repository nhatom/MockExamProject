using System.Security.Cryptography;
using System.Text;

namespace Project.Utilities
{
	public class Functions
	{
		public static int _UserID = 0;
		public static string _Username = string.Empty;
		public static string _Password = string.Empty;
		public static string _Email = string.Empty;
		public static string _Message = string.Empty;
		public static string _MessageEmail = string.Empty;
		public static string TitleSlugGeneration(string type, string title, long id)
		{
			string sTitle = type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
			return sTitle;
		}
		public static string getCurrentDate()
		{
			return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
		}

		public static string MD5Hash(string text)
		{
			using (MD5 md5 = MD5.Create()) // Sử dụng MD5.Create() thay vì MD5CryptoServiceProvider
			{
				byte[] data = md5.ComputeHash(Encoding.ASCII.GetBytes(text));
				StringBuilder strBuilder = new StringBuilder();
				for (int i = 0; i < data.Length; i++)
				{
					strBuilder.Append(data[i].ToString("x2"));
				}
				return strBuilder.ToString();
			}
		}

		public static string MD5Password(string? text)
		{
			string str = MD5Hash(text);
			for (int i = 0; i <= 5; i++)
				str = MD5Hash(str + "_" + str);
			return str;
		}

		public static bool IsLogin()
		{
			if (string.IsNullOrEmpty(Functions._Username) || string.IsNullOrEmpty(Functions._Email) || (Functions._UserID <= 0))
				return false;
			return true;
		}
	}
}