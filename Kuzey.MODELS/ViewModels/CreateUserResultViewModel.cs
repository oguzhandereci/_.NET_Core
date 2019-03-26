using Kuzey.MODELS.IdentityEntities;
using Microsoft.AspNetCore.Identity;

namespace Kuzey.MODELS.ViewModels
{
    public class CreateUserResultViewModel
    {
        public IdentityResult IdentityResult { get; set; }
        public AppUser User { get; set; }
    }
}
