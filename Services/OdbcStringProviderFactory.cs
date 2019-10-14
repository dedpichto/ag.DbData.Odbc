using ag.DbData.Abstraction.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ag.DbData.Odbc.Services
{
    /// <summary>
    /// Represents <see cref="OdbcStringProviderFactory"/> object.
    /// </summary>
    public class OdbcStringProviderFactory : IDbDataStringProviderFactory<OdbcStringProvider>
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates new instance of <see cref="OdbcStringProviderFactory"/>.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        public OdbcStringProviderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Creates object of type <see cref="OdbcStringProvider"/>.
        /// </summary>
        /// <returns>Object of type <see cref="OdbcStringProvider"/>.</returns>
        public OdbcStringProvider Get()
        {
            return _serviceProvider.GetService<OdbcStringProvider>();
        }
    }
}
