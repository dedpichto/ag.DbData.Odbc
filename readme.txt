
// add section to settings file (optional)
{
  "OdbcDbDataSettings": {
    "AllowExceptionLogging": false, // optional, default is "true"
    "ConnectionString": "YOUR_CONNECTION_STRING" // optional
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
		services.AddAgOdbc(config.GetSection("OdbcDbDataSettings"));
		// or
		services.AddAgOdbc(opts =>
        {
            opts.AllowExceptionLogging = false; // optional
			opts.ConnectionString = YOUR_CONNECTION_STRING; // optional
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

// in case you have defined connection string in configuration setting you may call Create() method
// without parameter

        using (var odbcDbData = _odbcFactory.Create())
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