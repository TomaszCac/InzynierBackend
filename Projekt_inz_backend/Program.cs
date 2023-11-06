using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projekt_inz_backend.Data;
using Projekt_inz_backend.Interfaces;
using Projekt_inz_backend.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEnemyActionEconomyRepository, EnemyActionEconomyRepository>();
builder.Services.AddScoped<IEnemyFeatureRepository, EnemyFeatureRepository>();
builder.Services.AddScoped<IEnemyRepository, EnemyRepository>();
builder.Services.AddScoped<IDndClassRepository, DndClassRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();
builder.Services.AddScoped<ISpellRepository, SpellRepository>();
builder.Services.AddScoped<ICustomDndClassFeatureRepository, CustomDndClassFeatureRepository>();
builder.Services.AddScoped<IDndClassFeatureRepository, DndClassFeatureRepository>();
builder.Services.AddScoped<IRaceFeatureRepository, RaceFeatureRepository>();
builder.Services.AddScoped<ICustomRaceFeatureRepository, CustomRaceFeatureRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISpellForClassRepository, SpellForClassRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DndDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DndDatabase")));



var app = builder.Build();
// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
    .AllowCredentials()); // allow credentials

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
