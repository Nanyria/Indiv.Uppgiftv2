using IndProjModels;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

public class ExcludePropertiesSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        // Replace "AppointmentDTO" with the actual class name you want to modify
        if (context.Type == typeof(AppointmentDTO))
        {
            // Replace "Changes" with the actual property name you want to exclude
            schema.Properties.Remove("changes");
        }
    }
}
