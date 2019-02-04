using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using udragan.netCore.SurveyMe.Auth;

namespace SurveyMe.Auth
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			/*services.AddDbContext<ApplicationIdentityDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationIdentityDbContext>()
				.AddDefaultTokenProviders();

			services.AddIdentityServer(options =>
			{
				options.Events.RaiseErrorEvents = true;
				options.Events.RaiseInformationEvents = true;
				options.Events.RaiseFailureEvents = true;
				options.Events.RaiseSuccessEvents = true;
			})
				.AddInMemoryIdentityResources(Config.GetIdentityResources())
				.AddInMemoryApiResources(Config.GetApis())
				.AddInMemoryClients(Config.GetClients())
				.AddTestUsers(Config.GetUsers())
				.AddAspNetIdentity<ApplicationUser>();*/

			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

			services.AddIdentityServer()
				.AddInMemoryIdentityResources(Config.GetIdentityResources())
				.AddInMemoryApiResources(Config.GetApis())
				.AddInMemoryClients(Config.GetClients())
				.AddTestUsers(Config.GetUsers())
				.AddDeveloperSigningCredential(); //TODO: set real credential for prod!!
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseStaticFiles();
			app.UseIdentityServer();
			app.UseMvcWithDefaultRoute();
		}
	}
}
