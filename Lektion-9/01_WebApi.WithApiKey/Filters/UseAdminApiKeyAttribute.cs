using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace _01_WebApi.WithApiKey.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class UseAdminApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apikey = configuration.GetValue<string>("AdminApiKey");

            // https://localhost:7071/api/products
            if (!context.HttpContext.Request.Headers.TryGetValue("Code", out var providedCode))
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

/*  
        HEADERS
        --------------------------------------------------------------------
        ContentType                     "Content-Type": "application/json"
        Authorization                   "Authorization": "bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c"
        
        Code                            "Code": "ZjFkOTI3OTUtMjZiZS00NDIwLWJjMTMtYTA3YTZlYzI3N2Q5"
*/