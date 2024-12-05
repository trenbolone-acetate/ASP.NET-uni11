using Microsoft.AspNetCore.Mvc.Filters;

using System.IO;
using System;
namespace ASPNET11.Filters;


public class UniqueUserCounterFilter : IActionFilter
{
    private static HashSet<string> uniqueUsers = new();

    public void OnActionExecuting(ActionExecutingContext context)
    {
        string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();

        if(uniqueUsers.Add(userAgent))
        {
            string logText = $"{DateTime.Now} : New user detected: {userAgent}\nTotal unique users: {uniqueUsers.Count}\n";

            Console.WriteLine(logText);
            File.AppendAllText("Log.txt", logText);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    } 
}