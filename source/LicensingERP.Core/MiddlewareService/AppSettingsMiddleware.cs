using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

public class AppSettingsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IConfiguration _configuration;

    public AppSettingsMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        _next = next;
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context); 
    }
}