
namespace KooliProjekt.BlazorApp.Api
{
    public interface IApiClient
    {
        Task<IList<Building>> List();
        Task Save(Building building);
        Task Delete(int id);
        Task<Result<Building>> Get(int id);

        Task<IList<BuildingPanels>> ListBuildingPanels();
        Task SaveBuildingPanel(BuildingPanels panel);
        Task DeleteBuildingPanel(int id);
    }
}