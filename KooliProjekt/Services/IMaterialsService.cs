using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Services
{
    public interface IMaterialsService
    {
        Task<PagedResult<Material>> List(int page, int pageSize, MaterialsSearch search);
        Task<Material> Get(int id);
        Task Save(Material list);
        Task Delete(int id);
    }
}