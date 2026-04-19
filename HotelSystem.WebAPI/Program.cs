using FluentValidation;
using FluentValidation.AspNetCore;
using HotelSystem.Application;
using HotelSystem.Application.Exceptions;
using HotelSystem.Application.Filters;
using HotelSystem.Application.IRepository.IUnitOfWork;
using HotelSystem.Application.Mapper;
using HotelSystem.Application.Valiadtion;
using HotelSystem.Domain.Models;
using HotelSystem.Infrastructure.DI;
using HotelSystem.Infrastructure.Repository.UOW;
using HotelSystem.WebAPI.OpenAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container. and configure the JSON options to use string enums
builder.Services.AddControllers(option =>
{
    option.Filters.Add<ValidateModelAttributer>();
}).AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    option.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull; 
});

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation(); 
builder.Services.AddValidatorsFromAssembly(ApplicationAssembly.assembly);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddHttpContextAccessor(); 
// Configure JWT authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(options =>{
    options.SaveToken = true;
    // In development, you might want to disable HTTPS requirement for testing purposes.
    options.RequireHttpsMetadata = false;
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            if (context.Exception is SecurityTokenExpiredException)
            {
                context.Response.Headers.Append("Token-Expired", "true");
            }
            return Task.CompletedTask;
        }
    };
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]!)),
    };
});



// register the services from the infrastructure layer DI container
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.Register();

// register the JwtSetting configuration
builder.Services.Configure<JwtSetting>(builder.Configuration.GetSection("JWT"));

// register the OpenAPI document and operation transformers
builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<InformationAPIDocument>(); 
    options.AddDocumentTransformer<BearerSecuritySchemaDocumention>();
    options.AddOperationTransformer<BearerSecuritySchemaOperations>();
});


var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "HotelSystem");
    });

    app.MapScalarApiReference();
}


app.MapControllers();

app.Run();
