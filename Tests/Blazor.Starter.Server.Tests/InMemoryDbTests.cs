using Blazor.Starter.Server.Interfaces;
using Blazor.Starter.Server.Models;
using Blazor.Starter.Server.Tests.Fixtures;

namespace Blazor.Starter.Server.Tests
{
    [Collection("ExampleTestCollection")]
    public class InMemoryDbTests
    {
        private readonly ExampleTestDbFixture _fixture;
        private IExampleDbContext _dbContext => _fixture._db;

        public InMemoryDbTests(ExampleTestDbFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task DB_CanInsert()
        {
            // Arrange
            var personId = Guid.NewGuid();
            var person = new Person()
            {
                PersonId = personId,
                FirstName = "Test User should not appear in PERSISTED DB AS THIS IS IN MEMORY"
            };

            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();

            // Act
            var personFromDB = _dbContext.People.FirstOrDefault(p => p.PersonId == personId);

            // Assert
            Assert.NotNull(personFromDB);
            Assert.Equal(person.PersonId, personFromDB?.PersonId);
            Assert.Equal(person.FirstName, personFromDB?.FirstName);
        }


        [Fact]
        public async Task DB_CanModify()
        {
            // Arrange
            var personId = Guid.NewGuid();
            var person = new Person()
            {
                PersonId = personId,
                FirstName = "Test User should not appear in PERSISTED DB AS THIS IS IN MEMORY"
            };

            _dbContext.People.Add(person);
            await _dbContext.SaveChangesAsync();

            string expectedNewName = "This isn't the test user you're looking for...";

            // Act
            // EF linq change tracker kicks in
            var fromDB = _dbContext.People.FirstOrDefault(p => p.PersonId == personId);

            // Assert
            Assert.NotNull(fromDB);

            // Act
            fromDB.FirstName = expectedNewName;

            Assert.Equal(fromDB?.FirstName, person.FirstName);

            // Save changes to in-mem db
            await _dbContext.SaveChangesAsync();

            Assert.Equal(expectedNewName, fromDB?.FirstName);

        }
    }
}