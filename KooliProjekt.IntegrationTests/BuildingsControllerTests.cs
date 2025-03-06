using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;  // <-- This ensures LINQ methods like FirstOrDefault, Any work
using KooliProjekt.Data;
using KooliProjekt.IntegrationTests.Helpers;
using Xunit;
using System;
using Microsoft.AspNetCore.Mvc.Testing;

namespace KooliProjekt.IntegrationTests
{
    [Collection("Sequential")]
    public class BuildingsControllerTests : TestBase
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;

        public BuildingsControllerTests()
        {
            var options = new WebApplicationFactoryClientOptions { AllowAutoRedirect = false };
            _client = Factory.CreateClient(options);
            _context = (ApplicationDbContext)Factory.Services.GetService(typeof(ApplicationDbContext));
        }

        [Fact]
        public async Task Index_should_return_correct_response()
        {
            // Arrange

            // Act
            using var response = await _client.GetAsync("/Buildings");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Details_should_return_notfound_when_list_was_not_found()
        {
            // Arrange

            // Act
            using var response = await _client.GetAsync("/Buildings/Details/100");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Details_should_return_notfound_when_id_is_missing()
        {
            // Arrange

            // Act
            using var response = await _client.GetAsync("/Buildings/Details/");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Details_should_return_ok_when_list_was_found()
        {
            // Arrange
            var list = new Building { Date = DateTime.Now, Title = "List 1" };
            _context.Building.Add(list);
            _context.SaveChanges();

            // Act
            using var response = await _client.GetAsync("/Buildings/Details/" + list.Id);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Create_should_save_new_building()
        {
            // Arrange
            var formValues = new Dictionary<string, string>
            {
                { "Id", "0" },
                { "Date", "2024-12-01" },
                { "Location", "Aruküla" }
            };

            using var content = new FormUrlEncodedContent(formValues);

            // Act
            using var response = await _client.PostAsync("/Buildings/Create", content);

            // Assert
            Assert.True(
                response.StatusCode == HttpStatusCode.Redirect ||
                response.StatusCode == HttpStatusCode.MovedPermanently);

            var building = _context.Building.FirstOrDefault();
            Assert.NotNull(building);
            Assert.NotEqual(0, building.Id);
            Assert.Equal("Aruküla", building.Location);
        }

        [Fact]
        public async Task Create_should_not_save_invalid_new_building()
        {
            // Arrange
            var formValues = new Dictionary<string, string>
            {
                { "UserId", "" },
                { "Date", "" },
                { "Location", "" }
            };

            using var content = new FormUrlEncodedContent(formValues);

            // Act
            using var response = await _client.PostAsync("/Buildings/Create", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.False(_context.Building.Any());
        }
    }
}
