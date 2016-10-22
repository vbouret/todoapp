using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.DataAccess.Repository
{
    /// <summary>
    /// BaseRepository class to allow injection of connectionString and databaseName from Autofac
    /// </summary>
    public abstract class BaseRepository
    {
        protected string dataSourceConnectionString;
        protected string databaseName;

        public BaseRepository(string dataSourceConnectionString, string databaseName)
        {
            this.dataSourceConnectionString = dataSourceConnectionString;
            this.databaseName = databaseName;
        }
    }
}
