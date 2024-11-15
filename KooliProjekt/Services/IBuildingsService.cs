using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IBuildingsService
    {
        Task<PagedResult<Building>> List(int page, int pageSize);
        Task<Building> Get(int id);
        Task Save(Building list);
        Task Delete(int id);
    }
}