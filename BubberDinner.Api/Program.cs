using BubberDinner.Api;
using BubberDinner.Api.Filters;
// using BubberDinner.Api.Middleware;
using BubberDinner.Application;
using BubberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
//Error handling second aproach
// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

var app = builder.Build();
//Error handling first aproach
//app.UseMiddleware<ErrorHandlingMiddleware>();

//Error handling third aproach
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.MapControllers();
app.Run();

