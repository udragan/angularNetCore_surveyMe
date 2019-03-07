using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using udragan.netCore.SurveyMe.Auth;
using udragan.netCore.SurveyMe.Auth.Contexts;
using udragan.netCore.SurveyMe.Auth.Models;

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
			/*services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationIdentityDbContext>()
				.AddDefaultTokenProviders();*/

			services.AddDbContext<ApplicationIdentityDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDatabase"));
			services.AddDefaultIdentity<ApplicationUser>()
				.AddEntityFrameworkStores<ApplicationIdentityDbContext>();

			services.AddMvc()
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

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
				.AddAspNetIdentity<ApplicationUser>()
				.AddDeveloperSigningCredential(); //TODO: set real credential for prod!!

			services.AddCors();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				SeedData(app);
			}

			// TODO: allow specific origins only!
			app.UseCors(x =>
			{
				x.AllowAnyOrigin();
				x.AllowAnyHeader();
				x.AllowAnyMethod();
			});

			app.UseStaticFiles();
			app.UseAuthentication();
			app.UseIdentityServer();
			app.UseMvcWithDefaultRoute();
		}

		private void SeedData(IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				//var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
				//context.Database.Migrate();

				var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
				var alice = userMgr.FindByNameAsync("alice").Result;
				if (alice == null)
				{
					alice = new ApplicationUser
					{
						UserName = "alice@email.com"
					};
					var result = userMgr.CreateAsync(alice, "Pass123$").Result;
					if (!result.Succeeded)
					{
						throw new Exception(result.Errors.First().Description);
					}

					result = userMgr.AddClaimsAsync(alice, new Claim[]{
						new Claim(JwtClaimTypes.Name, "Alice Smith"),
						new Claim(JwtClaimTypes.GivenName, "Alice"),
						new Claim(JwtClaimTypes.FamilyName, "Smith"),
						new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
						new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
						new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
						new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
					}).Result;
					if (!result.Succeeded)
					{
						throw new Exception(result.Errors.First().Description);
					}
					Console.WriteLine("alice created");
				}
				else
				{
					Console.WriteLine("alice already exists");
				}

				var bob = userMgr.FindByNameAsync("bob").Result;
				if (bob == null)
				{
					bob = new ApplicationUser
					{
						UserName = "bob@email.com"
					};
					var result = userMgr.CreateAsync(bob, "Pass123$").Result;
					if (!result.Succeeded)
					{
						throw new Exception(result.Errors.First().Description);
					}

					result = userMgr.AddClaimsAsync(bob, new Claim[]{
						new Claim(JwtClaimTypes.Name, "Bob Smith"),
						new Claim(JwtClaimTypes.GivenName, "Bob"),
						new Claim(JwtClaimTypes.FamilyName, "Smith"),
						new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
						new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
						new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
						new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json),
						new Claim("location", "somewhere")
					}).Result;
					if (!result.Succeeded)
					{
						throw new Exception(result.Errors.First().Description);
					}
					Console.WriteLine("bob created");
				}
				else
				{
					Console.WriteLine("bob already exists");
				}
			}
		}
	}
}
