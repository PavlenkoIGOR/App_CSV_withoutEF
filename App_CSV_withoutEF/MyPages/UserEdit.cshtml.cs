using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.Data.Models;
using App_CSV_withoutEF.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace App_CSV_withoutEF.MyPages
{
    public class UserEditModel : PageModel
    {
        [BindProperty] public User _user { get; set; }
        [BindProperty] public IEnumerable<User> Users { get; set; }
        [BindProperty] public string Org_Title { get; set; }
        [BindProperty] public Organization Organization { get; set; }
        public List<SelectListItem> orgs { get; set; }
        public IEnumerable<Organization>? Organizations { get; set; }


        private ICommonRepo _CommonRepo;
        private IUserRepo _UserRepo;
        private IOrganizationRepo _OrganizationRepo;

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
                orgs = Organizations.Select(org => new SelectListItem
                {
                    Text = org.Title_ORG,
                    Value = org.Title_ORG
                }).ToList();

            }
        }
        public async Task<IActionResult> OnPost()
        {
            string Title = Org_Title;
            Organization org = await _OrganizationRepo.GetOrganizationByTitle(Title);
            User newUser = new User()
            {
                UserName = _user.UserName,
                UserLastname = _user.UserLastname,
                UserSurname = _user.UserSurname,
                BirthDate = _user.BirthDate,
                PassportSerial = _user.PassportSerial,
                PassportNumber = _user.PassportNumber,
                UserOrganizationId = org.OrgId,
            };
            int userID = await _CommonRepo.AddEntity(newUser);
            Organizations = await _OrganizationRepo.GetOrganizations();
            Users = await _UserRepo.GetUsers();
            return RedirectToPage("/UserEdit");
        }
    }
}
