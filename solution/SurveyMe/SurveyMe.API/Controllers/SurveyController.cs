using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SurveyMe.API.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	public class SurveyController : ControllerBase
	{
		public SurveyController()
		{ }

		[Authorize]
		[HttpGet("all")]
		public async Task<IActionResult> GetAll()
		{
			IList<string> result = new List<string>
			{
				"test"
			};

			return Ok(result);
		}
	}
}