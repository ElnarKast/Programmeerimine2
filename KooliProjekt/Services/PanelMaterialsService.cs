using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class PanelMaterialsService : IPanelMaterialsService
    {
        private readonly ApplicationDbContext _context;

        public PanelMaterialsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<PanelMaterial>> List(int page, int pageSize)
        {
            return await _context.PanelMaterial.GetPagedAsync(page, 5);
        }

        public async Task<PanelMaterial> Get(int id)
        {
            return await _context.PanelMaterial.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Save(PanelMaterial list)
        {
            if (list.Id == 0)
            {
                _context.Add(list);
            }
            else
            {
                _context.Update(list);
            }

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var PanelMaterial = await _context.PanelMaterial.FindAsync(id);
            if (PanelMaterial != null)
            {
                _context.PanelMaterial.Remove(PanelMaterial);
                await _context.SaveChangesAsync();
            }
        }
    }
}
