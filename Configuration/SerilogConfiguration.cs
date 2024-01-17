﻿using Serilog.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;

namespace movies_api_pipeline_actions_azure_ci.Configuration
{
    public static class SerilogConfiguration
    {
        public static void AddSerilogConfiguration(this IServiceCollection services, IConfiguration configuration,
        IHostEnvironment environment)
        {
            var logConfig = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.WithProperty("Application", "MOVIES-API")
                .ReadFrom.Configuration(configuration)
                .WriteTo.File(
                    new CompactJsonFormatter(),
                    GetLogFilePath(environment),
                    rollingInterval: RollingInterval.Day,
                    retainedFileCountLimit: null)
                .WriteTo.Console(new CompactJsonFormatter())
                .CreateLogger();

            ILoggerProvider serilogProvider = new SerilogLoggerProvider(logConfig);

            services.AddSingleton<ILoggerProvider>(serilogProvider);
            services.AddSingleton<ILoggerFactory, LoggerFactory>(serviceProvider =>
            {
                var factory = new LoggerFactory();
                factory.AddProvider(serviceProvider.GetRequiredService<ILoggerProvider>());
                return factory;
            });
        }

        private static string GetLogFilePath(IHostEnvironment environment)
        {
            var folderPath = Path.Combine(environment.ContentRootPath, "Logs");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return Path.Combine(folderPath, "log.txt");
        }
    }
}
