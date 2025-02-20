using KooliProjekt.Data;
using KooliProjekt.Services;
using Xunit;

namespace KooliProjekt.UnitTests.ServiceTests
{
    public class BuildingPanelsServiceTests : ServiceTestBase
    {
        private readonly BuildingPanelsService _service;

        public BuildingPanelsServiceTests()
        {
            _service = new BuildingPanelsService(DbContext);
        }

        [Fact]
        public async Task Delete_should_remove_existing_list()
        {
            // Arrange
            var list = new BuildingPanels { Title = "Test" };
            DbContext.BuildingPanels.Add(list);  // Use the correct DbSet: BuildingPanels
            DbContext.SaveChanges();

            // Act
            await _service.Delete(list.Id);

            // Assert
            var count = DbContext.BuildingPanels.Count();  // Correct DbSet: BuildingPanels
            Assert.Equal(0, count);
        }

        [Fact]
        public async Task Delete_should_not_remove_when_list_was_not_found()
        {
            // Arrange
            var id = -100;  // A non-existent ID

            // Act
            await _service.Delete(id);

            // Assert
            var count = DbContext.BuildingPanels.Count();  // Correct DbSet: BuildingPanels
            Assert.Equal(0, count);  // No deletion should occur
        }
    }
}
