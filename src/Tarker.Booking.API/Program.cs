using Tarker.Booking.API;
using Tarker.Booking.Application;
using Tarker.Booking.Common;
using Tarker.Booking.External;
using Tarker.Booking.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Reference to dependency injections services
builder.Services
    .AddWebApi()
    .AddCommon()
    .AddApplication()
    .AddExternal(configuration: builder.Configuration)
    .AddPersistence(configuration: builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.MapControllers();
app.Run();