using ag.DbData.Abstraction.Services;
using ag.DbData.Odbc.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace ag.DbData.Odbc.Extensions
{
    /// <summary>
    /// Represents <see cref="ag.DbData.Odbc"/> extensions.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Appends the registration of <see cref="OdbcDbDataFactory"/> and <see cref="OdbcDbDataObject"/> services to <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgOdbc(this IServiceCollection services)
        {
            services.TryAddTransient<IDbDataStringProvider, DbDataStringProvider>();
            services.AddSingleton<IOdbcDbDataFactory, OdbcDbDataFactory>();
            services.AddTransient<OdbcDbDataObject>();
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="OdbcDbDataFactory"/> and <see cref="OdbcDbDataObject"/> services to <see cref="IServiceCollection"/> and registers a configuration instance.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configurationSection">The <see cref="IConfigurationSection"/> being bound.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgOdbc(this IServiceCollection services, IConfigurationSection configurationSection)
        {
            services.AddAgOdbc();
            services.Configure<OdbcDbDataSettings>(opts =>
            {
                opts.AllowExceptionLogging = configurationSection.GetValue<bool>("AllowExceptionLogging");
                opts.ConnectionString = configurationSection.GetValue<string>("ConnectionString");
            });
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="OdbcDbDataFactory"/> and <see cref="OdbcDbDataObject"/> services to <see cref="IServiceCollection"/> and configures the options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureOptions">The action used to configure the options.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgOdbc(this IServiceCollection services,
            Action<OdbcDbDataSettings> configureOptions)
        {
            services.AddAgOdbc();
            services.Configure(configureOptions);
            return services;
        }
    }
}
