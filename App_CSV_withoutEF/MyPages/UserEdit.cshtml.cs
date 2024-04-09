using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.Data.Models;
using App_CSV_withoutEF.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App_CSV_withoutEF.MyPages
{
    public class UserEditModel : PageModel
    {
        [BindProperty] public User _user { get; set; }
        [BindProperty] public IEnumerable<User> Users { get; set; }
        [BindProperty] public SelectList selectlist { get; set; }
        [BindProperty] public List<Organization>? Organizations { get; set; }
        public Organization Organization { get; set; }
        public string Org_Title { get; set; }
        
        



        private ICommonRepo _CommonRepo;
        private IUserRepo _UserRepo;
        private IOrganizationRepo _OrganizationRepo;


        //public new record class User(string UserName, string UserLastname, string UserSurname, DateTime BirthDate, int PassportSerial, int PassportNumber, int UserOrganizationId);
        public UserEditModel(ICommonRepo commonRepo, IUserRepo userRepo, IOrganizationRepo organizationRepo)
        {
            _CommonRepo = commonRepo;
            _UserRepo = userRepo;
            _OrganizationRepo = organizationRepo;
        }
        public async void OnGet()
        {
            Users = await _UserRepo.GetUsers();

            Organizations = await _OrganizationRepo.GetOrganizations();
            if (Organizations != null)
            {
                selectlist = new SelectList(Organizations.Select(s => s.Title_ORG));
            }
            

            List<Organization> organizations = new List<Organization>();
        }

        public async void OnPost()
        {
            Organization org = await _OrganizationRepo.GetOrganizationByTitle(Org_Title);
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
