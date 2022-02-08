using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _01_WebApi.WithApiKey.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class UseApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apikey = configuration.GetValue<string>("ApiKey");

            // https://localhost:7071/api/products?code=
            if(!context.HttpContext.Request.Query.TryGetValue("code", out var providedCode))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            if (!apikey.Equals(providedCode))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();
        }
    }
}
