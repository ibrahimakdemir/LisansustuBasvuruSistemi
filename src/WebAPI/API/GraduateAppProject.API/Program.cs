using GraduateAppProject.Infrastructure.Data;
using GraduateAppProject.Repositories;
using GraduateAppProject.Services;
using GraduateAppProject.Services.Mappings;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICitizenService, CitizenService>();
builder.Services.AddScoped<ICitizenInformationService, CitizenInformationService>();
builder.Services.AddScoped<ICitizenRepository, EFCitizenRepository>();
builder.Services.AddScoped<ICitizenInformationRepository, EFCitizenInformationRepository>();

builder.Services.AddAutoMapper(typeof(MapProfile));



var connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<CitizensInfoApiDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("allow", builder =>
    {
        builder.AllowAnyHeader();
        builder.AllowAnyMethod();
        builder.AllowAnyMethod();
        builder.AllowAnyOrigin();
    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<CitizensInfoApiDbContext>();
var configuration = services.GetRequiredService<IConfiguration>();
//context.Database.EnsureCreated(); --> Because dbfirst is used
DbSeeding.SeedDatabase(context, configuration);


app.UseHttpsRedirection();
app.UseCors("allow");
app.UseAuthorization();

app.MapControllers();

app.Run();

