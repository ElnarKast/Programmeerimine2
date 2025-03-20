using Xunit;
using Moq;
using KooliProjekt.WpfApp;
using KooliProjekt.WpfApp.Api;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

public class MainWindowViewModelTests
{
    private readonly Mock<IApiClient> _mockApiClient;
    private readonly MainWindowViewModel _viewModel;

    public MainWindowViewModelTests()
    {
        _mockApiClient = new Mock<IApiClient>();
        _viewModel = new MainWindowViewModel(_mockApiClient.Object);
    }

    [Fact]
    public void NewCommand_Executes_CreatesNewCategory()
    {
        // Act
        _viewModel.NewCommand.Execute(null);

        // Assert
        Assert.NotNull(_viewModel.SelectedItem);
    }

    [Fact]
    public async Task SaveCommand_Executes_CallsApiClient()
    {
        // Arrange
        var category = new Building { Id = 1, Title = "Test" };
        _viewModel.SelectedItem = category;
        _mockApiClient.Setup(api => api.Save(category)).Returns(Task.CompletedTask);

        // Act
        _viewModel.SaveCommand.Execute(null);

        // Assert
        _mockApiClient.Verify(api => api.Save(category), Times.Once);
    }

    [Fact]
    public void SaveCommand_CanExecute_ReturnsFalse_WhenNoItemSelected()
    {
        // Arrange
        _viewModel.SelectedItem = null;

        // Act
        bool result = _viewModel.SaveCommand.CanExecute(null);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public async Task Load_FillsLists()
    {
        // Arrange
        var categories = new List<Building> { new Building { Id = 1, Title = "Test" } };
        _mockApiClient.Setup(api => api.List()).ReturnsAsync(categories);

        // Act
        await _viewModel.Load();

        // Assert
        Assert.Single(_viewModel.Lists);
    }

    [Fact]
    public void ConfirmDelete_ReturnsTrue_WhenPredicateAllows()
    {
        // Arrange
        var category = new Building();
        _viewModel.SelectedItem = category;
        _viewModel.ConfirmDelete = item => true;

        // Act
        bool canDelete = _viewModel.ConfirmDelete(category);

        // Assert
        Assert.True(canDelete);
    }

    [Fact]
    public void ConfirmDelete_ReturnsFalse_WhenPredicateDenies()
    {
        // Arrange
        var category = new Building();
        _viewModel.SelectedItem = category;
        _viewModel.ConfirmDelete = item => false;

        // Act
        bool canDelete = _viewModel.ConfirmDelete(category);

        // Assert
        Assert.False(canDelete);
    }
}