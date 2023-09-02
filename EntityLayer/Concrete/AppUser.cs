using Microsoft.AspNetCore.Identity;

namespace EntityLayer.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        public string NameSurename { get; set; }
        public string ImageURL { get; set; }
    }
}

