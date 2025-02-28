using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace KooliProjekt.Data
{
    public class Building
    {
        public int Id { get; set; }


        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        public string Location { get; set; }
        public string Title { get; set; }
    }
}
