using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.BLL.Services;
using App_CSV_withoutEF.Data.Models;
using App_CSV_withoutEF.Pages;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace App_CSV_withoutEF.MyPages
{
    public class UserEditModel : PageModel
    {
        [BindProperty] public User _user { get; set; }
        [BindProperty] public List<User> Users { get; set; }
        [BindProperty] public string Org_Title { get; set; }
        [BindProperty] public Organization Organization { get; set; }

        public IEnumerable<CSV_User> csv_Users { get; set; }
        public List<SelectListItem> orgs { get; set; }
        public IEnumerable<Organization>? Organizations { get; set; }


        private ICommonRepo _CommonRepo;
        private IUserRepo _UserRepo;
        private IOrganizationRepo _OrganizationRepo;
        private IMapper _mapper;

        public UserEditModel(ICommonRepo commonRepo, IUserRepo userRepo, IOrganizationRepo organizationRepo, IMapper mapper)
        {
            _CommonRepo = commonRepo;
            _UserRepo = userRepo;
            _OrganizationRepo = organizationRepo;
            _mapper = mapper;
        }
        public async void OnGet()
        {
            Org_Title = "";
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
            if (Organizations != null)
            {
                orgs = Organizations.Select(org => new SelectListItem
                {
                    Text = org.Title_ORG,
                    Value = org.Title_ORG
                }).ToList();
            }
            Users = await _UserRepo.GetUsers();
            return RedirectToPage("/UserEdit");
        }

        public async Task<IActionResult> OnPostWriteToCSV()
        {
            Users = await _UserRepo.GetUsers();
            List<CSV_User> csv_Users = _mapper.Map<List<User>, List<CSV_User>>(Users);
            await CSVManager.WritoToCSV(csv_Users);
            return RedirectToPage("/UserEdit");
        }

        public async Task OnPostReadFromCSV()
        {
            csv_Users = await CSVManager.ReadFromCSV<CSV_User>();
            Organizations = await _OrganizationRepo.GetOrganizations();
            if (Organizations != null)
            {
                orgs = Organizations.Select(org => new SelectListItem
                {
                    Text = org.Title_ORG,
                    Value = org.Title_ORG
                }).ToList();
            }
            //Users = await _UserRepo.GetUsers();
            //return RedirectToAction("OnGet");
        }
    }
}
