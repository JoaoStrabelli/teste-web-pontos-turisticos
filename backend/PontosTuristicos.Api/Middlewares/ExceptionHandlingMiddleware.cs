using System.Net;
using System.Text.Json;

namespace PontosTuristicos.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger)
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
        catch (ArgumentException exception)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.BadRequest,
                exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "Erro inesperado ao processar a requisição.");

            await HandleExceptionAsync(
                context,
                HttpStatusCode.InternalServerError,
                "Ocorreu um erro inesperado. Tente novamente mais tarde.");
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        HttpStatusCode statusCode,
        string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var response = new
        {
            message
        };

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}