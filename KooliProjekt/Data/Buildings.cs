using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;

namespace KooliProjekt.Data
{
    public class Building
    {
        public int Id { get; set; }


        public IdentityUser User { get; set; }
        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }
    }
}
