using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IBuildingPanelsService
    {
        Task<PagedResult<BuildingPanels>> List(int page, int pageSize);
        Task<BuildingPanels> Get(int id);
        Task Save(BuildingPanels list);
        Task Delete(int id);
    }
}