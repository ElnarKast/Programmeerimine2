using KooliProjekt.Data;
using Microsoft.EntityFrameworkCore;

namespace KooliProjekt.Services
{
    public class PanelsService : IPanelsService
    {
        private readonly ApplicationDbContext _context;

        public PanelsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Panel>> List(int page, int pageSize)
        {
            return await _context.Panel.GetPagedAsync(page, 5);
        }

        public async Task<Panel> Get(int id)
        {
            return await _context.Panel.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Save(Panel list)
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
            var panel = await _context.Panel.FindAsync(id);
            if (panel != null)
            {
                _context.Panel.Remove(panel);
                await _context.SaveChangesAsync();
            }
        }
    }
}
