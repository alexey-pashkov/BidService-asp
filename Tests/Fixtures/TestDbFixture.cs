using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docker.DotNet.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace Tests.Fixtures
{
    public class TestDbFixture : IDisposable
    {
        private PostgreSqlContainer dbContainer;

        //public PostgreSqlContainer DbContainer { get { return dbContainer; } }

        public TestDbFixture()
        {
            var ContainerConfig = new PostgreSqlConfiguration("test_db", "postgres", "postgres");

            this.dbContainer = new PostgreSqlContainer(ContainerConfig);

            this.dbContainer.StartAsync();
        }

        public void Dispose()
        {
            this.dbContainer.StopAsync();
        }

        public string GetConnectionString()
        {
            return this.dbContainer.GetConnectionString();
        }
    }
}
