using HotelSystem.Infrastructure.DI;
using HotelSystem.WebAPI.OpenAPI;
using Scalar.AspNetCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(option =>
{
    option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddAuthentication().AddJwtBearer();

builder.Services.AddInfrastructure(builder.Configuration);




builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer<InformationAPIDocument>(); 
    options.AddDocumentTransformer<BearerSecuritySchemaDocumention>();
    options.AddOperationTransformer<BearerSecuritySchemaOperations>();
});


var app = builder.Build();



if(app.Environment.IsDevelopment())
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
