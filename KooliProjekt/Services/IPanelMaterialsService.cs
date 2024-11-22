using KooliProjekt.Data;

namespace KooliProjekt.Services
{
    public interface IPanelMaterialsService
    {
        Task<PagedResult<PanelMaterial>> List(int page, int pageSize);
        Task<PanelMaterial> Get(int id);
        Task Save(PanelMaterial list);
        Task Delete(int id);
    }
}