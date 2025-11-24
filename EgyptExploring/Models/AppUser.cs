using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EgyptExploring.Models
{
    public class AppUser:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Trip> Trips { get; set; }

    }
}
