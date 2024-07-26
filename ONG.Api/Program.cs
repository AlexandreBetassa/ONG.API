using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ONG.Api.Domain.Commands.v1.Person.CreatePerson;
using ONG.Api.Domain.Interfaces.v1.Configurations.v1;
using ONG.Api.Domain.Interfaces.v1.Repositories;
using ONG.Api.Domain.Interfaces.v1.Services;
using ONG.Api.Infrastructure.Configurations.v1;
using ONG.Api.Infrastructure.Data;
using ONG.Api.Infrastructure.Data.v1.Context;
using ONG.Api.Infrastructure.Data.v1.Repositories;
using ONG.Api.Services.v1;
using System.Text;

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

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection(nameof(JwtConfiguration)));

builder.Services.AddMediatR(opt =>
                                opt.RegisterServicesFromAssembly(typeof(CreatePersonCommandHandler).Assembly));

builder.Services.AddAutoMapper(opt =>
                                opt.AddMaps(typeof(CreatePersonCommandProfile).Assembly));

builder.Services.AddScoped(typeof(IData<>), typeof(Data<>));
builder.Services.AddTransient(typeof(IPersonRepository<>), typeof(PersonRepository<>));
builder.Services.AddTransient<IUnityOfWork, UnityOfWork>();
builder.Services.AddTransient<ILoggerFactory, LoggerFactory>();
builder.Services.AddTransient<IPasswordServices, PasswordService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient(typeof(PasswordHasher<>));
builder.Services.AddSingleton<IJwtConfiguration>(sp => sp.GetRequiredService<IOptions<JwtConfiguration>>().Value);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["Database"]));

// Configurando autenticação via swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API ONG - AdotaPet", Version = "v1" });

    c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Description =
            "JWT Authorization Header - Utilizado com Bearer Authentication.\r\n\r\n" +
            "Digite seu token no campo abaixo.\r\n\r\n" +
            "Exemplo (informar apenas o token): '12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var jwtConfig = builder.Configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>();

builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = false;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.SecretJwtKey)),
            ValidIssuer = jwtConfig.Issuer,
            ValidAudience = jwtConfig.Audience,
            ValidateIssuer = true,
            ValidateAudience = true
        };
    });


builder.Services.AddAuthorizationBuilder()
    .AddPolicy("write", policy => policy.RequireRole(jwtConfig.WriteRoles))
    .AddPolicy("read", policy => policy.RequireRole(jwtConfig.ReadRoles));

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