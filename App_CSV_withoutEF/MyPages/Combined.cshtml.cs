using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace App_CSV_withoutEF.MyPages
{
    public class Common
    {
        internal string orgTitle { get; set; }
        internal string employeeLastName { get; set; }
        internal int userPassportSerial { get; set; }
        internal int userPassportNumber { get; set; }
    }

    public class CombinedModel : PageModel
    {
        private ICommonRepo _repoCommon;
        private IUserRepo _repoUser;
        private IOrganizationRepo _repoOganization;

        [BindProperty] public List<Common> common {  get; set; }

        public CombinedModel(ICommonRepo commonRepo, IUserRepo userRepo, IOrganizationRepo organizationRepo)
        {
            _repoCommon = commonRepo;
            _repoUser = userRepo;
            _repoOganization = organizationRepo;
        }
        public async Task OnGet()
        {
            List<User> users = await _repoUser.GetUsers();
            List<Organization> organizations = await _repoOganization.GetOrganizations();

            common = (from u in users
                         join o in organizations on u.UserOrganizationId equals o.OrgId
                         orderby o.Title_ORG
                         select new Common{ orgTitle = o.Title_ORG, employeeLastName = u.UserLastname, userPassportSerial = u.PassportSerial, userPassportNumber = u.PassportNumber }
                         ).ToList();


        }
    }
}
