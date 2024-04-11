using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.BLL.Services;
using App_CSV_withoutEF.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace App_CSV_withoutEF.MyPages
{
    public class OrganizationEditModel : PageModel
    {
        [BindProperty] public Organization organization { get; set; }
        

        private IOrganizationRepo _organizationRepo;
        private ICommonRepo _commonRepo;
        private IMapper _mapper;
        public List<Organization> organizations { get; set; }


        public OrganizationEditModel(ICommonRepo commonRepo, IOrganizationRepo organizationRepo, IMapper mapper)
        {
            _commonRepo = commonRepo;
            _organizationRepo = organizationRepo;
            _mapper = mapper;
        }
        public async Task OnGet()
        {
            organizations = await _organizationRepo.GetOrganizations();

        }
        public async Task<IActionResult> OnPost() 
        {
            Organization newOrganization = new Organization() 
            {
                Title_ORG = organization.Title_ORG,
                INN_ORG = organization.INN_ORG,
                UrAddress_ORG = organization.UrAddress_ORG,
                FactAddress_ORG = organization.FactAddress_ORG
            };
            int orgId = await _commonRepo.AddEntityAndGetId(newOrganization);
            return RedirectToPage("/OrganizationEdit");
        }

        public async Task<IActionResult> OnPostWriteToCSV()
        {
            organizations = await _organizationRepo.GetOrganizations();
            List<CSV_Organization> csv_Organizations = _mapper.Map<List<Organization>, List<CSV_Organization>>(organizations);
            await CSVManager.WritoToCSV(csv_Organizations);

            return RedirectToPage("/OrganizationEdit");
        }

        public async Task<IActionResult> OnPostReadFromCSV()
        {
            //csvOrg = await CSVManager.ReadFromCSV<CSV_Organization>();
            return RedirectToPage("/OrgFromCSV");
        }
    }
}
