using Gotrays.Service.Contract.Jwt;
using Gotrays.Service.Hubs;
using Gotrays.Service.Infrastructure.EntityFrameworkCore;
using Gotrays.Service.Infrastructure.Expressions;
using Gotrays.Service.Infrastructure.Middlewares;
using Masa.BuildingBlocks.Data.UoW;
using Masa.BuildingBlocks.Ddd.Domain.Repositories;
using MessagePack;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

#region Jwt

var jwtSection = builder.Configuration.GetSection("Jwt");
builder.Services.Configure<JwtOptions>(jwtSection);
var jwtOptions = jwtSection.Get<JwtOptions>();
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

#endregion

builder.Services
    .AddTransient<AbnormalMiddleware>()
    .AddSignalR()
    .AddMessagePackProtocol(options =>
    {
        options.SerializerOptions = MessagePackSerializerOptions.Standard
            .WithSecurity(MessagePackSecurity.UntrustedData);
    });

var app = builder.Services
    .AddEndpointsApiExplorer()
    .AddAuthorization()
    .AddMasaIdentity()
    .AddHttpContextAccessor()
    .AddJwtBearerAuthentication(jwtOptions)
    .AddSwaggerGen(options =>
    {
        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description =
                "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer xxxxxxxxxxxxxxx\"",
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GotraysApp", Version = "v1", Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "GotraysApp", } });
        foreach (var item in Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml")) options.IncludeXmlComments(item, true);
        options.DocInclusionPredicate((docName, action) => true);
    })
    .AddDomainEventBus(dispatcherOptions =>
    {
        dispatcherOptions
            .UseEventBus()
            .UseUoW<GotraysDbContext>()
            .UseRepository<GotraysDbContext>();
        ;
    })
    .AddEventBus()
    .AddMasaDbContext<GotraysDbContext>(opt =>
    {
        opt.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"] ?? throw new InvalidOperationException());
    })
    .AddAutoInject()
    .AddServices(builder, option => option.MapHttpMethodsForUnmatched = new[] { "Post" });

app.UseMiddleware<AbnormalMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger().UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "GotraysApp"));
}

app.MapHub<ChatHub>("/ChatHub");

await app.RunAsync();