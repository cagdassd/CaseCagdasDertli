using Entities.Concrete;
using System.Net;
using WebAPI.Controllers;

namespace WebAPI.Miwleaware
{
	public class Exception
	{
		public class ExceptionMiddleware
		{
			private readonly RequestDelegate _next;
			private readonly ILogger _logger;
			public ExceptionMiddleware(RequestDelegate next)
			{
				_next = next;
			}

			public async Task InvokeAsync(HttpContext httpContext)
			{
				try
				{
					await _next(httpContext);
				}
				catch (System.Exception ex)
				{
                    _logger.LogError(ex.Message);
					await HandleExceptionAsync(httpContext, ex);
				}
			}

			private static Task HandleExceptionAsync(HttpContext httpContext, System.Exception ex)
			{

				httpContext.Response.ContentType = "application/json";
				httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
				var now = DateTime.UtcNow;
				return httpContext.Response.WriteAsync(new ApiResponse<string>()
				{
					ErrorCode = httpContext.Response.StatusCode.ToString(),
					ResultMessage = ex.Message,
					Status = Status.Failed
				}.ToString());
			}
		}
	}
}
