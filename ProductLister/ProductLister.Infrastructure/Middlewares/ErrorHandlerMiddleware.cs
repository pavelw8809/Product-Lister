using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using System.Net;
using System.Text.Json;

namespace ProductLister.Infrastructure.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ErrorHandlerMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (SqlException ex)
            {
                await HandleExceptionAsync(context, ex, "Database SQL Error", HttpStatusCode.InternalServerError);
            }
            catch (TimeoutException ex)
            {
                await HandleExceptionAsync(context, ex, "Database Timeout", HttpStatusCode.RequestTimeout);
            }
            catch (InvalidOperationException ex)
            {
                await HandleExceptionAsync(context, ex, "Invalid Database Operation", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, "Unhandled Server Error", HttpStatusCode.InternalServerError);
            }
        }

        public static async Task HandleExceptionAsync(HttpContext context, Exception ex, string message, HttpStatusCode statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var errorResponse = new
            {
                statusCode = context.Response.StatusCode,
                message,
                details = ex.Message
            };

            var json = JsonSerializer.Serialize(errorResponse);
            await context.Response.WriteAsync(json);
        }
    }
}
