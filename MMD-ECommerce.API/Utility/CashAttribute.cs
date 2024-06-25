using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MMD_ECommerce.Service.Abstractions;
using System.Text;

namespace MMD_ECommerce.API.Utility
{
    public class CashAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _time;

        public CashAttribute(int time)
        {
            _time = time;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var cashKey = GenerateKeyFromRequest(context.HttpContext.Request);

            var _cashService = context.HttpContext.RequestServices.GetRequiredService<ICashService>();

            var cashResponse = await _cashService.GetCashResponseAsync(cashKey);
            if (cashResponse is not null)
            {
                var result = new ContentResult
                {
                    ContentType = "application/json",
                    StatusCode = 200,
                    Content = cashResponse
                };
                context.Result = result;
                return;
            }

            var excutedContext = await next();

            if (excutedContext.Result is OkObjectResult response)
            {
                await _cashService.SetCashResponseAsync(cashKey, response.Value, TimeSpan.FromMinutes(_time));
            }
        }

        private string GenerateKeyFromRequest(HttpRequest request)
        {
            StringBuilder key = new StringBuilder();

            key.Append($"{request.Path}");

            foreach (var item in request.Query.OrderBy(x => x.Key))
            {
                key.Append(item);
            }

            return key.ToString();
        }
    }
}
