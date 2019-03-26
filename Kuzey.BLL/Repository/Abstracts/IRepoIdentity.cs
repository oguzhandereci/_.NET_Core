using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Kuzey.MODELS.IdentityEntities;
using Kuzey.MODELS.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Kuzey.BLL.Repository.Abstracts
{
    public interface IRepoIdentity
    {
        Task<CreateUserResultViewModel> RegisterUser(RegisterViewModel model);
        Task<SignInResult> LoginUser(LoginViewModel model);
        Task Logout();
        Task CreateRoles();
        Task AddRole(AppUser user);
    }
}
