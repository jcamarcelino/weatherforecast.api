using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Api.Configurations
{
    public static class RedocConfiguration
    {
        public static void UseReDoc(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseReDoc(c =>
            {
                c.RoutePrefix = $"doc";
                c.DocumentTitle = "Documentação da api BR One.";
                c.SpecUrl($"/swagger/v1/swagger.json");
                c.SortPropsAlphabetically();
                c.HideDownloadButton();
            });

            foreach (var description in provider.ApiVersionDescriptions)
            {
                app.UseReDoc(c =>
                {
                    c.RoutePrefix = $"doc/{description.GroupName}";
                    c.DocumentTitle = "Documentação da api BR One.";
                    c.SpecUrl($"/swagger/{description.GroupName}/swagger.json");
                    c.SortPropsAlphabetically();
                    c.HideDownloadButton();
                });
            }
        }
    }
}
