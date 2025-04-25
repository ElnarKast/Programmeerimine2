using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.BlazorApp.Api
{
    public class Building
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public string Location { get; set; }
        public string Title { get; set; }
    }
}
