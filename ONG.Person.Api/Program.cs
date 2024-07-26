using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ONG.Person.Api.Domain.Commands.v1.Person.CreatePerson;
using ONG.Person.Api.Domain.Interfaces.v1;
using ONG.Person.Api.Domain.Interfaces.v1.Services;
using ONG.Person.Api.Infrastructure.Data;
using ONG.Person.Api.Infrastructure.Data.Context;
using ONG.Person.Api.Infrastructure.Data.Repositories.v1;
using ONG.Person.Api.Services.v1;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(opt =>
                                opt.RegisterServicesFromAssembly(typeof(CreatePersonCommandHandler).Assembly));

builder.Services.AddAutoMapper(opt =>
                                opt.AddMaps(typeof(CreatePersonCommandProfile).Assembly));

builder.Services.AddScoped(typeof(IData<>), typeof(Data<>));
builder.Services.AddTransient(typeof(IPersonRepository<>), typeof(PersonRepository<>));
builder.Services.AddTransient(typeof(IPetRepository<>), typeof(PetRepository<>));
builder.Services.AddTransient<IUnityOfWork, UnityOfWork>();
builder.Services.AddTransient<ILoggerFactory, LoggerFactory>();
builder.Services.AddTransient<IPasswordServices, PasswordService>();
builder.Services.AddTransient(typeof(PasswordHasher<>));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["Database"]));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();