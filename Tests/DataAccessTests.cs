using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Tests.Fixtures;

namespace Tests
{
    public class DataAccessTests : IClassFixture<TestDbFixture>
    {

        private TestDbFixture fixture;

        public DataAccessTests(TestDbFixture fixture) 
        { 
            this.fixture = fixture;
        }

        [Fact]
        public void TestDbConnection()
        {
            var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                    .UseNpgsql(this.fixture.ConnectionString)
                    .Options;

            using (var context = new AppDbContext(contextOptions))
            {
                Assert.True(context.Database.CanConnect());
            }
        }

        [Fact]
        public void TestAddEntity()
        {
            var contextOptions = new DbContextOptionsBuilder<AppDbContext>()
                    .UseNpgsql(this.fixture.ConnectionString)
                    .Options;

            using (var context = new AppDbContext(contextOptions))
            {
                var bidCreator = new BidCreator { Name = "John Doe", Email = "doe@email.org" };

                context.bidCreators.Add(bidCreator);
                var written = context.SaveChanges();
            }

            BidCreator fromDb;

            using (var context = new AppDbContext(contextOptions))
            {
                fromDb = context.bidCreators.FirstOrDefault();
            }

            Assert.NotNull(fromDb);
            Assert.Equal("John Doe", fromDb.Name);

        }
    }
}
