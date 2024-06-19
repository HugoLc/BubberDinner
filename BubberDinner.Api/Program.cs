using BubberDinner.Api.Filters;
// using BubberDinner.Api.Middleware;
using BubberDinner.Application;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

var app = builder.Build();
//Error handling first aproach
//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

