using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IPanelsService
    {
        Task<PagedResult<Panel>> List(int page, int pageSize);
        Task<Panel> Get(int id);
        Task Save(Panel list);
        Task Delete(int id);
    }
}