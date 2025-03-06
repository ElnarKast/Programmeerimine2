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
    public class PanelsControllerTests : TestBase
    {
        private readonly HttpClient _client;
        private readonly ApplicationDbContext _context;

        public PanelsControllerTests()
        {
            var options = new WebApplicationFactoryClientOptions { AllowAutoRedirect = false };
            _client = Factory.CreateClient(options);
            _context = (ApplicationDbContext)Factory.Services.GetService(typeof(ApplicationDbContext));
        }

        [Fact]
        public async Task Index_should_return_correct_response()
        {
            // Act
            using var response = await _client.GetAsync("/Panels");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Details_should_return_notfound_when_panel_not_found()
        {
            // Act
            using var response = await _client.GetAsync("/Panels/Details/100");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Details_should_return_notfound_when_id_is_missing()
        {
            // Act
            using var response = await _client.GetAsync("/Panels/Details/");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Details_should_return_ok_when_panel_found()
        {
            // Arrange
            var panel = new Panel { Title = "Test Panel" };  // Renamed 'list' to 'panel'
            _context.Panel.Add(panel);
            _context.SaveChanges();

            // Act
            using var response = await _client.GetAsync("/Panels/Details/" + panel.Id);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Create_should_save_new_panel()
        {
            // Arrange
            var formValues = new Dictionary<string, string>();
            formValues.Add("Id", "0");
            formValues.Add("Title", "Test Panel");

            using var content = new FormUrlEncodedContent(formValues);

            // Act
            using var response = await _client.PostAsync("/Panels/Create", content);

            // Assert
            Assert.True(
                response.StatusCode == HttpStatusCode.Redirect ||
                response.StatusCode == HttpStatusCode.MovedPermanently);

            var panel = _context.Panel.FirstOrDefault();
            Assert.NotNull(panel);
            Assert.NotEqual(0, panel.Id);
            Assert.Equal("Test Panel", panel.Title);
        }

        [Fact]
        public async Task Create_should_not_save_invalid_new_panel()
        {
            // Arrange: Prepare form values with invalid data (empty Title)
            var formValues = new Dictionary<string, string>();
            //formValues.Add("Title", "");  // Empty Title, which should be invalid

            using var content = new FormUrlEncodedContent(formValues);

            // Act: Post the form to create a new panel
            using var response = await _client.PostAsync("/Panels/Create", content);

            // Assert: 
            // Check that the response is a redirection (302) or Moved Permanently
            response.EnsureSuccessStatusCode();

            // Ensure no new panel was added to the database
            Assert.False(_context.Panel.Any(), "A new panel was added when the title was empty.");
        }

    }
}
