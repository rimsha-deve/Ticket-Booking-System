
using Azure.Core;

namespace TicketBookingSystem.Application.DTOs;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public int StatusCode { get; set; } = 200;
    public string? Message { get; set; }
    public List<FieldError> FieldErrors { get; set; } = [];
    public T? Data { get; set; }

    // SUCCESS RESPONSE
    public static ApiResponse<T> SuccessResponse(
        T? data,
        int statusCode = 200,
        string message = "Request successful")
    {
        return new ApiResponse<T>
        {
            Success = true,
            StatusCode = statusCode,
            Message = message,
            Data = data
        };
    }

    // FAILURE RESPONSE
    public static ApiResponse<T> FailureResponse(
        int statusCode = 400,
        string message = "Request failed",
        List<FieldError>? fieldErrors = null)
    {
        return new ApiResponse<T>
        {
            Success = false,
            Message = message,
            StatusCode = statusCode,
            FieldErrors = fieldErrors ?? [],
            Data = default
        };
    }
}

public class FieldError
{
    public string? FieldName { get; set; }
    public string? ErrorMessage { get; set; }
}
