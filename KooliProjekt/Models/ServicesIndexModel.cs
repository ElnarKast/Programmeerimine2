using KooliProjekt.Data;
using KooliProjekt.Search;

namespace KooliProjekt.Models
{
    public class ServicesIndexModel
    {
        public ServicesSearch Search { get; set; }
        public PagedResult<Service> Data { get; set; }
    }
}
