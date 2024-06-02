using CleanArchitecture.Api.Common.Errors;
using CleanArchitecture.Api.Filters;
using CleanArchitecture.Api.Middleware;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    //builder.Services.AddControllers(options=>options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, CleanArchitectureProblemDetailsFactory>();

}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}

