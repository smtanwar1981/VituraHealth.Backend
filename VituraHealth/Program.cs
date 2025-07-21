using VituraHealth.Api.Extensions;
using VituraHealth.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);


/********** RegisterServices - an extension method to register all the dependencies ******/
builder.Services.RegisterServices();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("VirtualHealthAllowOrigin");

//app.RegisterAppServices();

app.Run();
