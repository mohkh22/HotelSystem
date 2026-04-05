using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace HotelSystem.WebAPI.OpenAPI
{
    public sealed class BearerSecuritySchemaOperations : IOpenApiOperationTransformer
    {
        public Task TransformAsync(OpenApiOperation operation, OpenApiOperationTransformerContext context, CancellationToken cancellationToken)
        {
           var hasAuthorize = context.Description.ActionDescriptor
                           .EndpointMetadata.OfType<AuthorizeAttribute>()
                            .Any ();

            if (hasAuthorize)
            {
                operation.Security ??= new List<OpenApiSecurityRequirement>();
                operation.Security.Add(new OpenApiSecurityRequirement
                {
                    [
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            },
                        }
                    ] = Array.Empty<string>()
                }); 

            }



            return Task.CompletedTask;

        }
    }
}
