using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace udragan.netCore.SurveyMe.Auth.Contexts
{
	public class ApplicationIdentityDbContext : IdentityDbContext
	{
		public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
			: base(options)
		{ }
	}
}
