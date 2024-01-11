using System.ComponentModel.DataAnnotations;

namespace Registration_Namespace
{
	public class RegisterDTO
	{
		[EmailAddress]
		[Required]
		public String Email { get; set; }
		[Required]
		public String Firstname { get; set; }
		[Required]
		public String Password { get; set; }

		[Required]
		public String username {  get; set; }
	}
}