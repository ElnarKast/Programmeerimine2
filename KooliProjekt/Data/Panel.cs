using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Panel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
