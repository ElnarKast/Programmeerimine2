using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Models
{
    public class MaterialsIndexModel
    {
        public MaterialsSearch Search { get; set; }
        public PagedResult<Material> Data { get; set; }
    }
}
