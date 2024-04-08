using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App_CSV_withoutEF.MyPages
{
    public class UserEditModel : PageModel
    {
        [BindProperty] public User _user {  get; set; }
        [BindProperty] public List<User> Users { get; set; }

        private ICommonRepo _CommonRepo;
        private IUserRepo _UserRepo;


        //public new record class User(string UserName, string UserLastname, string UserSurname, DateTime BirthDate, int PassportSerial, int PassportNumber, int UserOrganizationId);
        public UserEditModel(ICommonRepo commonRepo, IUserRepo userRepo)
        {
            _CommonRepo = commonRepo;
            _UserRepo = userRepo;
        }
        public async void OnGet()
        {
           Users = await _UserRepo.GetUsers();


            List<Organization> organizations = new List<Organization>();
        }

        public async void OnPost() 
        {
            User newUser = new User()
            {
                UserName = _user.UserName,
                UserLastname = _user.UserLastname,
                UserSurname = _user.UserSurname,
                BirthDate = _user.BirthDate,
                PassportSerial = _user.PassportSerial,
                PassportNumber = _user.PassportNumber,
                UserOrganizationId = _user.UserOrganizationId,
            };
            int userID = await _CommonRepo.AddEntity(newUser);
        }
    }
}
