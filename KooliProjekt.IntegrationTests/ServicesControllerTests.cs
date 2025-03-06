using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using KooliProjekt.Data;
using KooliProjekt.IntegrationTests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace KooliProjekt.IntegrationTests
{
    [Collection("Sequential")]
    public class ServicesControllerTests : TestBase
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;

        public ServicesControllerTests()
        {
            var options = new WebApplicationFactoryClientOptions { AllowAutoRedirect = false };
            _client = Factory.CreateClient(options);
            _context = (ApplicationDbContext)Factory.Services.GetService(typeof(ApplicationDbContext));
        }

        [Fact]
        public async Task Index_should_return_correct_response()
        {
            // Act
            using var response = await _client.GetAsync("/Services");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Details_should_return_notfound_when_service_not_found()
        {
            // Act
            using var response = await _client.GetAsync("/Services/Details/100");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Details_should_return_notfound_when_id_is_missing()
        {
            // Act
            using var response = await _client.GetAsync("/Services/Details/");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Details_should_return_ok_when_service_found()
        {
            // Arrange
            var service = new Service { Title = "Service 1" };  // Changed 'list' to 'service'
            _context.Service.Add(service);
            _context.SaveChanges();

            // Act
            using var response = await _client.GetAsync("/Services/Details/" + service.Id);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Create_should_save_new_service()
        {
            // Arrange
            var formValues = new Dictionary<string, string>();
            formValues.Add("Id", "0");
            formValues.Add("Title", "Test Service");

            using var content = new FormUrlEncodedContent(formValues);

            // Act
            using var response = await _client.PostAsync("/Services/Create", content);

            // Assert
            Assert.True(
                response.StatusCode == HttpStatusCode.Redirect ||
                response.StatusCode == HttpStatusCode.MovedPermanently);

            var service = _context.Service.FirstOrDefault();
            Assert.NotNull(service);
            Assert.NotEqual(0, service.Id);
            Assert.Equal("Test Service", service.Title);
        }

        [Fact]
        public async Task Create_should_not_save_invalid_new_service()
        {
            // Arrange:
            // Step 1: Create and save a new Building
            var building = new Building { Title = "Test Building", Date = DateTime.Now };
            _context.Building.Add(building);
            await _context.SaveChangesAsync(); // Save to get the building's ID

            // Step 2: Prepare form values with an empty Title for the Service (invalid input)
            var formValues = new Dictionary<string, string>
            {
            { "Title", "" },  // Empty Title (invalid)'
            { "Price", "" },  // Empty Title (invalid)
            { "BuildingId", building.Id.ToString() }  // Add the BuildingId to the form values
            };

            using var content = new FormUrlEncodedContent(formValues);

            // Act:
            // Step 3: Post the form to create a new Service
            using var response = await _client.PostAsync("/Services/Create", content);

            // Assert:
            response.EnsureSuccessStatusCode();

            // Step 4: Ensure no new Service was added to the database
            Assert.False(_context.Service.Any(), "A new service was added when the title was empty.");
        }


    }
}
