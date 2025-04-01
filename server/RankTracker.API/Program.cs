using RankTracker.Bing.Extensions;
using RankTracker.Core;
using RankTracker.EFCore;
using RankTracker.Google.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreServices(builder.Configuration);

builder.Services.AddEFCoreServices(builder.Configuration);

builder.Services.AddGoogleServices(builder.Configuration);

builder.Services.AddBingServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    // We have allow all ports for now, just incase user is running the client app on different port
    options.AddDefaultPolicy(policy =>
                        {
                            policy.WithOrigins("http://localhost:*", "https://localhost:*");
                        });
});



builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors(x => x.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
