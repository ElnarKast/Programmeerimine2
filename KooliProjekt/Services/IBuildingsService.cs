using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface IBuildingsService
    {
        Task<PagedResult<Building>> List(int page, int pageSize, BuildingsSearch search);
        Task<Building> Get(int id);
        Task Save(Building list);
        Task Delete(int id);        
    }
}