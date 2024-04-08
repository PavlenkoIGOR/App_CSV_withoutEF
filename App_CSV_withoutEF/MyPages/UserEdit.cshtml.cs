using App_CSV_withoutEF.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App_CSV_withoutEF.MyPages
{
    public class UserEditModel : PageModel
    {
        internal User _user; 
        public void OnGet()
        {
            List<User> users = new List<User>();

        }

        public void OnPost() 
        {
            User newUser = new User()
            {
                UserName = _user.UserName,
                UserLastname = _user.UserLastname,
                UserSurname = _user.UserSurname,
                UserOrganization = _user.UserOrganization,
                BirthDate = _user.BirthDate,
            };
        }
    }
}
