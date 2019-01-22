using Microsoft.AspNetCore.Identity;

namespace udragan.netCore.SurveyMe.Auth.Models
{
	public class ApplicationUser : IdentityUser
	{
		public bool IsAdmin { get; set; }
	}
}
