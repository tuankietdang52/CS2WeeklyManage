using CS2WeeklyManage.Configs;
using CS2WeeklyManage.Data;
using CS2WeeklyManage.Models.Commons;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AllowCORS()
				.RegisterDbContext(builder.Configuration)
				.RegisterRepositories()
				.RegisterServices();

var app = builder.Build();

if (args.Contains("seed"))
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;
    var logger = services.GetRequiredService<ILogger<Program>>();
    var dbContext = services.GetRequiredService<AppDbContext>();

	logger.LogInformation("Seeding");
    SeedData.Seeding(logger, dbContext);
}

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
