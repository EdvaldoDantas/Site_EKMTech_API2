using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
public class ErrorController
{
    private readonly RequestDelegate _next;
    public ErrorController(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }
    private Task HandleExceptionAsync(HttpContext context, Exception e)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        var response = new 
        {
            statuscode = StatusCodes.Status500InternalServerError,
            message ="Ocorreu Algum erro interno, estámos trabalhando para retornar o mais rápido possível",
            error = e.Message
        };
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}