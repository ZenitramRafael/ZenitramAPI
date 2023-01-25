using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using ZenitramAPI.Models;

namespace ZenitramAPI.Controllers
{
    [AttributeUsage(validOn: AttributeTargets.Class)]
    internal class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private string APIKEYNAME { get; } = "x-api-key";

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key was not provided"
                };
                return;
            }

            var appSettings = context.HttpContext.RequestServices.GetRequiredService<IOptions<AzureOptions>>();

            var apiKey = appSettings.Value.MessageApiKey;

            if (!apiKey.Equals(extractedApiKey.ToString()))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Api Key is not valid"
                };
                return;
            }

            await next();
        }
    }
}