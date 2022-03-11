using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Filters;
using Serilog.Templates;
using Serilog.Templates.Themes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherForecast.Api.Configurations
{
    public static class SerilogConfiguration
    {
        public static void AddSerilog(this IServiceCollection services)
        {
            string logFileName = Path.Combine(AppContext.BaseDirectory, "Log\\log.txt");

            var loggerConfiguration = new LoggerConfiguration()
                 .Filter.ByExcluding(Matching.FromSource("Microsoft"))
                 .Filter.ByExcluding("RequestPath like '/health%'")
                 .Filter.ByExcluding("contextType like 'HealthChecksDb'")
                 .Filter.ByExcluding("Contains(SourceContext,'health')")
                 .Filter.ByExcluding("Contains(SourceContext,'HealthChecks')")
                 .Enrich.FromLogContext()
                 .WriteTo.Console(new ExpressionTemplate("[{@t:HH:mm:ss} {@l:u3}] {@m}\n{@x}", theme: TemplateTheme.Code))
                 .WriteTo.Debug(outputTemplate: DateTime.Now.ToString())
                 .WriteTo.File(logFileName,
                        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {RequestId,13} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                        rollingInterval: RollingInterval.Day);

            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            string seqUrl = configuration.GetSection("Logging:Seq:Url")?.Get<string>();

            if (!string.IsNullOrWhiteSpace(seqUrl))
                loggerConfiguration.WriteTo.Seq(seqUrl);

            Log.Logger = loggerConfiguration.CreateLogger();
        }

        public static void UseSerilogRequestLogging(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging(options =>
            {
                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("Host", httpContext.Request.Host);
                    diagnosticContext.Set("Protocol", httpContext.Request.Protocol);
                    diagnosticContext.Set("Scheme", httpContext.Request.Scheme);
                };
                options.MessageTemplate = "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ";
                options.IncludeQueryInRequestPath = true;
            });
        }
    }
}
