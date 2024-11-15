using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class BuildingPanelsService : IBuildingPanelsService
    {
        private readonly ApplicationDbContext _context;

        public BuildingPanelsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<BuildingPanels>> List(int page, int pageSize)
        {
            return await _context.BuildingPanels.GetPagedAsync(page, 5);
        }

        public async Task<BuildingPanels> Get(int id)
        {
            return await _context.BuildingPanels.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Save(BuildingPanels list)
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
            var BuildingPanel = await _context.BuildingPanels.FindAsync(id);
            if (BuildingPanel != null)
            {
                _context.BuildingPanels.Remove(BuildingPanel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
