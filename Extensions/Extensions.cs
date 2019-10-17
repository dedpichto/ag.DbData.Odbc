using ag.DbData.Abstraction;
using ag.DbData.Odbc.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using ag.DbData.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
            services.Configure<DbDataSettings>(configurationSection);
            return services;
        }

        /// <summary>
        /// Appends the registration of <see cref="OdbcDbDataFactory"/> and <see cref="OdbcDbDataObject"/> services to <see cref="IServiceCollection"/> and configures the options.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="configureOptions">The action used to configure the options.</param>
        /// <returns><see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddAgOdbc(this IServiceCollection services,
            Action<DbDataSettings> configureOptions)
        {
            services.AddAgOdbc();
            services.Configure(configureOptions);
            return services;
        }
    }
}
