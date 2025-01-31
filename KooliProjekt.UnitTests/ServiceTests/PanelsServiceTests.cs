using KooliProjekt.Data;
using KooliProjekt.Services;
using Xunit;

namespace KooliProjekt.UnitTests.ServiceTests
{
    public class PanelsServiceTests : ServiceTestBase
    {
        private readonly PanelsService _service;

        public PanelsServiceTests()
        {
            _service = new PanelsService(DbContext);
        }

        [Fact]
        public async Task Delete_should_remove_existing_list()
        {
            // Arrange
            var list = new Panel { Title = "Test" };
            DbContext.Panel.Add(list);
            DbContext.SaveChanges();

            // Act
            await _service.Delete(list.Id);

            // Assert
            var count = DbContext.Panel.Count();
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
            var count = DbContext.Panel.Count();
            Assert.Equal(0, count);
        }
    }
}