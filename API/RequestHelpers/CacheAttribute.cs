using System.Text;
using Core.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.RequestHelpers;

[AttributeUsage(AttributeTargets.All)]
public class CacheAttribute(int timeToLiveSeconds) : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var cachecService = context.HttpContext.RequestServices.GetRequiredService<IResponseCacheService>();
        var cacheKey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

        var cacheResponse = await cachecService.GetCachedResponseAsync(cacheKey);

        if(!string.IsNullOrEmpty(cacheResponse)){
            var contentResult = new ContentResult
            {
                Content = cacheResponse,
                ContentType = "application/json",
                StatusCode = 200
            };

            context.Result = contentResult;

            return;
        }

        var executeContext = await next();

        if(executeContext.Result is OkObjectResult okObjectResult)
        {
            if(okObjectResult.Value != null)
            {
                await cachecService.CacheResponseAsync(cacheKey, okObjectResult.Value, TimeSpan.FromSeconds(timeToLiveSeconds));
            }
        }
    }

    private string GenerateCacheKeyFromRequest(HttpRequest httpRequest)
    {
        var keyBuilder = new StringBuilder();
        keyBuilder.Append($"{httpRequest.Path}");

        foreach (var (key, value) in httpRequest.Query.OrderBy(x => x.Key))
        {
            keyBuilder.Append($"|{key}-{value}");
        }

        return keyBuilder.ToString();
    }
}
