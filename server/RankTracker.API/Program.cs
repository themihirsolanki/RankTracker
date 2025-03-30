using Microsoft.EntityFrameworkCore;
using RankTracker.EFCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEFCoreServices(builder.Configuration);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
                        {
                            policy.WithOrigins("http://localhost:4200");
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
