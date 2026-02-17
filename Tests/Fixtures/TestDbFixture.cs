using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Testcontainers.PostgreSql;

namespace Tests.Fixtures
{
    public class TestDbFixture
    {
        private PostgreSqlContainer dbContainer;

        public TestDbFixture() 
        {

           this.dbContainer = new PostgreSqlBuilder()
                .WithImage()
        }
    }
}
