using ag.DbData.Abstraction;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data.Odbc;

namespace ag.DbData.Odbc.Factories
{
    /// <summary>
    /// Represents OdbcDbDataFactory object.
    /// </summary>
    public class OdbcDbDataFactory : IOdbcDbDataFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Creates object of type <see cref="OdbcDbDataObject"/>.
        /// </summary>
        /// <returns><see cref="OdbcDbDataObject"/> implementation of <see cref="IDbDataObject"/> interface.</returns>
        public IDbDataObject Create()
        {
            var dbObject = _serviceProvider.GetService<OdbcDbDataObject>();
            return dbObject;
        }

        /// <summary>
        /// Creates object of type <see cref="OdbcDbDataObject"/>.
        /// </summary>
        /// <param name="connectionString">Database connection string.</param>
        /// <returns><see cref="OdbcDbDataObject"/> implementation of <see cref="IDbDataObject"/> interface.</returns>
        public IDbDataObject Create(string connectionString)
        {
            var dbObject = _serviceProvider.GetService<OdbcDbDataObject>();
            dbObject.Connection = new OdbcConnection(connectionString);
            return dbObject;
        }
        
        /// <summary>
        /// Creates new OdbcDbDataFactory object.
        /// </summary>
        /// <param name="serviceProvider"><see cref="IServiceProvider"/>.</param>
        public OdbcDbDataFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
