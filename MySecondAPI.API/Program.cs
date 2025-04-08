using MySecondAPI.Application.Interfaces.Services;
using MySecondAPI.Application.Interfaces.Repositories;
using MySecondAPI.Application.Services;
using MySecondAPI.Infrastructure.Repositories;
using MySecondAPI.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(PersonMappingProfile).Assembly);
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IPersonService, PersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();