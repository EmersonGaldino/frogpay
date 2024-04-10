using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace frogpay.bootstrapper.Configurations.Performance.Filters;

public class PerformaceFilters : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var clock = new Stopwatch();
        clock.Start();

        var resultContext = await next();
        clock.Stop();

        if (resultContext.Result is ObjectResult view)
        {
            var item = view.Value;
            if (item.GetType().GetProperty("TimerProcessing") != null)
                item.GetType().GetProperty("TimerProcessing")?.SetValue(item, Convert.ToInt32(clock.Elapsed.TotalMilliseconds));
            view.Value = item;
            
        }

    }
}