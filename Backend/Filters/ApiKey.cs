using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Filters
{
	public class ApiKey : Attribute, IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var config = context.HttpContext.RequestServices.GetService<IConfiguration>();
			var apiKey = config!.GetValue<string>("ApiKey");

			if (!context.HttpContext.Request.Query.TryGetValue("key", out var key))
			{
				context.Result = new UnauthorizedResult();
				return;
			}

			if (!apiKey!.Equals(key))
			{
				context.Result = new UnauthorizedResult();
				return;
			}

			await next();
		}
	}
}
