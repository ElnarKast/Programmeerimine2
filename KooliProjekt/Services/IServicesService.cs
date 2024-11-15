using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IServicesService
    {
        Task<PagedResult<Service>> List(int page, int pageSize);
        Task<Service> Get(int id);
        Task Save(Service list);
        Task Delete(int id);
    }
}