using KooliProjekt.Data;
using KooliProjekt.Services;
using Xunit;

namespace KooliProjekt.UnitTests.ServiceTests
{
    public class BuildingsServiceTests : ServiceTestBase
    {
        private readonly BuildingsService _service;

        public BuildingsServiceTests()
        {
            _service = new BuildingsService(DbContext);
        }

        [Fact]
        public async Task Delete_should_remove_existing_list()
        {
            // Arrange
            var list = new Building
            {
                Title = "Test",
                Date = DateTime.UtcNow // Set the Date property
            };
            DbContext.Building.Add(list);
            DbContext.SaveChanges();

            // Act
            await _service.Delete(list.Id);

            // Assert
            var count = DbContext.Building.Count();
            Assert.Equal(0, count);
        }


        [Fact]
        public async Task Delete_should_return_if_list_was_not_found()
        {
            // Arrange
            var id = -100;

            // Act
            await _service.Delete(id);

            // Assert
            var count = DbContext.Building.Count();
            Assert.Equal(0, count);
        }
    }
}