using ProjetoAds.Application.Application;
using ProjetoAds.Application.Contracts;
using ProjetoAds.CrossCutting.ExtensionMethods;
using ProjetoAds.CrossCutting.Helpers.Auth.Services;
using ProjetoAds.CrossCutting.Settings;
using ProjetoAds.Data.Repository;
using ProjetoAds.Domain.Repository;
using ProjetoAds.Domain.Service;
using ProjetoAds.Domain.Service.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwagger();
builder.Services.AddJwtBearerAuthentication(builder.Configuration);

ConfigureSettings(builder);
ConfigureServices(builder);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
    builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

void ConfigureSettings(WebApplicationBuilder builder)
{
    var settings = new Settings();
    builder.Configuration.GetSection("ConnectionStrings").Bind(settings);
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddControllers();

    builder.Services.AddTransient<IUserApplication, UserApplication>();
    builder.Services.AddTransient<IUserService, UserService>();
    builder.Services.AddTransient<IUserRepository, UserRepository>();

    builder.Services.AddTransient<IChampionshipApplication, ChampionshipApplication>();
    builder.Services.AddTransient<IChampionshipService, ChampionshipService>();
    builder.Services.AddTransient<IChampionshipRepository, ChampionshipRepository>();


    builder.Services.AddTransient<IGameApplication, GameApplication>();
    builder.Services.AddTransient<IGameService, GameService>();
    builder.Services.AddTransient<IGameRepository, GameRepository>();

    builder.Services.AddScoped<IAuthApplication, AuthApplication>();
    builder.Services.AddScoped<ITokenService, TokenService>();
}