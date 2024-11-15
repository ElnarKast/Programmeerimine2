using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class BuildingsService : IBuildingsService
    {
        private readonly ApplicationDbContext _context;

        public BuildingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Building>> List(int page, int pageSize)
        {
            return await _context.Building.GetPagedAsync(page, 5);
        }

        public async Task<Building> Get(int id)
        {
            return await _context.Building.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Save(Building list)
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
            var building = await _context.Building.FindAsync(id);
            if (building != null)
            {
                _context.Building.Remove(building);
                await _context.SaveChangesAsync();
            }
        }
    }
}
