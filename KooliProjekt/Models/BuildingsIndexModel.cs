using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Models
{
    public class BuildingsIndexModel
    {
        public BuildingsSearch Search { get; set; }
        public PagedResult<Building> Data { get; set; }
    }
}
