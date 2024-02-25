using Microsoft.AspNetCore.Identity;
using ClinicAngularAPI.Models;

namespace ClinicAngularAPI.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(SignUp signUp);
        Task<SignInResult> SignIn(SignIn signIn);
        Task Logout();

        Task<IdentityResult> AddRole(Role role);

        List<UsersDTO> getUsers();

        Task<List<UserRoles>> getRoles(string UserId);


		Task UpdateUserRoles(List<UserRoles> liUserRoles);

        Task<ApplicationUsers> getUSerInfo(string username);


        List<string> getUserRoles(ApplicationUsers obj);

	}
}
