using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace HotelSystem.WebAPI.OpenAPI
{
    public sealed class InformationAPIDocument : IOpenApiDocumentTransformer
    {
        public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context, CancellationToken cancellationToken)
        {
            document.Info = new()
            {
                Title = "HotelSystem",
                Version = "v1",
                Description = "this the first version",
                //TermsOfService=new Uri("https://locakslmmdszx"),
                Contact = new OpenApiContact
                {
                    Name = "Mohamed",
                    //Url = new Uri("contactURI"),
                    Email = "Mohamed@gmail.com",
                },
                License = new OpenApiLicense
                {
                    Name = "Mohamed",
                    //Url = new Uri("LicienceURI"),
                }
            };
            return Task.CompletedTask;

        }
    }
}
