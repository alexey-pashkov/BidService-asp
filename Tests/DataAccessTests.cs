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
        public void TestAddEntity()
        {
            var contextOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            contextOptionsBuilder.UseNpgsql(this.fixture.GetConnectionString());

            using (var context = new AppDbContext(contextOptionsBuilder.Options))
            {
                var bidCreator = new BidCreator { Name = "John Doe", Email = "doe@email.org" };

                context.bidCreators.Add(bidCreator);
                var written = context.SaveChanges();
            }

            BidCreator fromDb;

            using (var context = new AppDbContext(contextOptionsBuilder.Options))
            {
                fromDb = context.bidCreators.FirstOrDefault();
            }

            Assert.NotNull(fromDb);
            Assert.Equal("John Doe", fromDb.Name);

        }
    }
}
