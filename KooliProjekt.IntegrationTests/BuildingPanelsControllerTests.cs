﻿using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;  // <-- Add this line
using KooliProjekt.Data;
using KooliProjekt.IntegrationTests.Helpers;
using Xunit;

namespace KooliProjekt.IntegrationTests
{
    [Collection("Sequential")]
    public class BuildingPanelsControllerTests : TestBase
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;

        public BuildingPanelsControllerTests()
        {
            _client = Factory.CreateClient();
            _context = (ApplicationDbContext)Factory.Services.GetService(typeof(ApplicationDbContext));
        }

        [Fact]
        public async Task Index_should_return_correct_response()
        {
            // Arrange

            // Act
            using var response = await _client.GetAsync("/BuildingPanels");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Details_should_return_notfound_when_list_was_not_found()
        {
            // Arrange

            // Act
            using var response = await _client.GetAsync("/BuildingPanels/Details/100");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Details_should_return_notfound_when_id_is_missing()
        {
            // Arrange

            // Act
            using var response = await _client.GetAsync("/BuildingPanels/Details/");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Details_should_return_ok_when_list_was_found()
        {
            // Arrange
            var list = new BuildingPanels { Title = "List 1" };
            _context.BuildingPanels.Add(list);
            _context.SaveChanges();

            // Act
            using var response = await _client.GetAsync("/BuildingPanels/Details/" + list.Id);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Create_should_save_new_list()
        {
            // Arrange
            var formValues = new Dictionary<string, string>();
            formValues.Add("Id", "0");
            formValues.Add("Title", "Test");

            using var content = new FormUrlEncodedContent(formValues);

            // Act
            using var response = await _client.PostAsync("/BuildingPanels/Create", content);

            // Assert
            Assert.True(
                response.StatusCode == HttpStatusCode.Redirect ||
                response.StatusCode == HttpStatusCode.MovedPermanently);

            var list = _context.BuildingPanels.FirstOrDefault(); // Now this should work
            Assert.NotNull(list);
            Assert.NotEqual(0, list.Id);
            Assert.Equal("Test", list.Title);
        }

        [Fact]
        public async Task Create_should_not_save_invalid_new_list()
        {
            // Arrange
            var formValues = new Dictionary<string, string>();
            formValues.Add("Title", "");

            using var content = new FormUrlEncodedContent(formValues);

            // Act
            using var response = await _client.PostAsync("/BuildingPanels/Create", content);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.False(_context.BuildingPanels.Any());
        }
    }
}
