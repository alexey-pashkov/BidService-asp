using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Docker.DotNet.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;
using Testcontainers.Xunit;
using Xunit.Sdk;

namespace Tests.Fixtures
{
    public class TestDbFixture : ContainerFixture<PostgreSqlBuilder, PostgreSqlContainer>
    {
        public string ConnectionString { get { return Container.GetConnectionString(); } }

        public TestDbFixture(IMessageSink messageSink) : base(messageSink)
        {
        }

        protected override PostgreSqlBuilder Configure(PostgreSqlBuilder builder)
        {
            return builder.WithImage("postgres:18.2-alpine3.22");
        }

    }
}
