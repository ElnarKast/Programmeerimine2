using KooliProjekt.Data;
using KooliProjekt.Search;
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

        public async Task Delete(int id)
        {
            await _context.Building
                .Where(list => list.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<Building> Get(int id)
        {
            return await _context.Building.FindAsync(id);
        }

        public async Task<PagedResult<Building>> List(int page, int pageSize, BuildingsSearch search = null)
        {
            var query = _context.Building.AsQueryable();

            search = search ?? new BuildingsSearch();

            if (!string.IsNullOrWhiteSpace(search.Keyword))
            {
                query = query.Where(list => list.Location.Contains(search.Keyword));
            }

            return await query
                .OrderBy(list => list.Location)
                .GetPagedAsync(page, pageSize);
        }

        public async Task Save(Building list)
        {
            if (list.Id == 0)
            {
                _context.Building.Add(list);
            }
            else
            {
                _context.Building.Update(list);
            }

            await _context.SaveChangesAsync();
        }
    }
}
