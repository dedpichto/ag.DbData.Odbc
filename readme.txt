
// add section to settings file (optional)
{
  "DbDataSettings": {
    "AllowExceptionLogging": false // default is "true" 
  }
}

***************************************************************************************************

// add appropriate usings
using ag.DbData.Odbc.Extensions;
using ag.DbData.Odbc.Factories;

***************************************************************************************************

// register services with extension method

		// ...
		services.AddAgOdbc();
		// or
		services.AddAgOdbc(config.GetSection("DbDataSettings"));
		// or
		services.AddAgOdbc(opts =>
        {
            opts.AllowExceptionLogging = false; 
        });

***************************************************************************************************

// inject IOdbcDbDataFactory into your classes

        private readonly IOdbcDbDataFactory _odbcFactory;

        public MyClass(IOdbcDbDataFactory odbcFactory)
        {
            _odbcFactory = odbcFactory;
        }

***************************************************************************************************

// OdbcDbDataObject implements IDisposable interface, so use it into 'using' directive

        using (var odbcDbData = _odbcFactory.Create(YOUR_CONNECTION_STRING))
        {
            using (var t = odbcDbData.FillDataTable("SELECT * FROM YOUR_TABLE"))
            {
                foreach (DataRow r in t.Rows)
                {
                    Console.WriteLine(r[0]);
                }
            }
        }

***************************************************************************************************