using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IMaterialsService
    {
        Task<PagedResult<Material>> List(int page, int pageSize);
        Task<Material> Get(int id);
        Task Save(Material list);
        Task Delete(int id);
    }
}