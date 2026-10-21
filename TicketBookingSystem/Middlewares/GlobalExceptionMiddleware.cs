using System.Net;
using System.Text.Json;
using TicketBookingSystem.Application.DTOs;
using TicketBookingSystem.Domain.Exception;
using TicketBookingSystem.Domain.Exceptions;
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            //_logger.LogError(
            //    ex,
            //    "Request failed. TraceId: {TraceId}",
            //    context.TraceIdentifier);

            if (context.Response.HasStarted)
            {
                throw;
            }

            context.Response.Clear();

            var (statusCode, message) = ex switch
            {
                BadRequestException =>
                    (HttpStatusCode.BadRequest, ex.Message),

                NotFoundException =>
                    (HttpStatusCode.NotFound, ex.Message),

                ConflictException =>
                    (HttpStatusCode.Conflict, ex.Message),

                //KeyNotFoundException =>
                //     (HttpStatusCode.Status404NotFound, ex.Message),

                //    ArgumentException =>
                //        (HttpStatusCode.Status400BadRequest, ex.Message),

                UnauthorizedException =>
                    (HttpStatusCode.Unauthorized, ex.Message),

                _ =>
                    (HttpStatusCode.InternalServerError,
                     "An unexpected error occurred.")
            };

            context.Response.StatusCode = (int)statusCode;
            context.Response.ContentType = "application/json";

            var response = ApiResponse<object>.FailureResponse(
               message: message,
               statusCode: (int)statusCode
           );
            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}
