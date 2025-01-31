using KooliProjekt.Data;
using KooliProjekt.Services;
using Xunit;

namespace KooliProjekt.UnitTests.ServiceTests
{
    public class BuildingPanelsTests : ServiceTestBase
    {
        private readonly BuildingPanelsService _service;

        public BuildingPanelsTests()
        {
            _service = new BuildingPanelsService(DbContext);
        }

        [Fact]
        public async Task Delete_should_remove_existing_list()
        {
            // Arrange
            var list = new BuildingPanels { Title = "Test" };
            DbContext.BuildingPanels.Add(list);
            DbContext.SaveChanges();

            // Act
            await _service.Delete(list.Id);

            // Assert
            var count = DbContext.BuildingPanels.Count();
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
            var count = DbContext.BuildingPanels.Count();
            Assert.Equal(0, count);
        }
    }
}