using Resorter.Domain.Exceptions;
using System.Net;

namespace Resorter.API.Middleware;

public class ErrorHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next.Invoke(context);
		}
		catch (NotFoundException notFound)
		{
			context.Response.StatusCode = (int)HttpStatusCode.NotFound;
			await context.Response.WriteAsync(notFound.Message);
		}
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync($"Error: {ex.Message}");
        }
    }
}
