using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using phoenix.domains;

namespace phoenix.graph.repositories
{
    public class DataContext : IDisposable
    {
        private bool _disposed = false;
        private readonly IDriver _driver;

        ~DataContext() => Dispose(false);

        public DataContext()
        {
            Settings.Load();
            _driver = GraphDatabase.Driver(Settings.Neo4jSettings.neo4jURI, AuthTokens.Basic(Settings.Neo4jSettings.neo4jUser, Settings.Neo4jSettings.neo4jPassword));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _driver?.Dispose();
            }

            _disposed = true;
        }
    }


}
