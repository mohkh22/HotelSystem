using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;

namespace HotelSystem.WebAPI.OpenAPI
{
    public sealed class BearerSecuritySchemaDocumention(IAuthenticationSchemeProvider authenticationService) : IOpenApiDocumentTransformer
    {
        public async Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {
            var authenticationScheme = await authenticationService.GetAllSchemesAsync(); 
            if(authenticationScheme.Any(c=>c.Name =="Bearer"))
            {
                var securitySchema = new Dictionary<string, OpenApiSecurityScheme>()
                {
                    ["Bearer"] = new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.Http,
                            Description = "this is Authentication",
                            Name = "Authentication",
                            In = ParameterLocation.Header,
                            Scheme = "bearer",
                            BearerFormat="Json web Token"

                        }

                };
                document.Components ??= new OpenApiComponents();
                document.Components.SecuritySchemes = securitySchema; 
            }
        }
    }
}
