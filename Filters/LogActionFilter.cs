namespace ASPNET11.Filters;

using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;
using System;

public class LogActionFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext filterContext)
    {
        string actionName = filterContext.ActionDescriptor.RouteValues["action"];
        string logText = $"{DateTime.Now}: {actionName} action is executing.\n";

        Console.WriteLine(logText);
        File.AppendAllText("Log.txt", logText);
    }

    public void OnActionExecuted(ActionExecutedContext filterContext)
    {
    }
}