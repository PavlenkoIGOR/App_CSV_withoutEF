using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.BLL.Services;
using App_CSV_withoutEF.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App_CSV_withoutEF.MyPages
{
    public class OrgFromCSVModel : PageModel
    {
        private ICommonRepo _CommonRepo;
        private IUserRepo _UserRepo;
        private IOrganizationRepo _OrganizationRepo;
        private IMapper _mapper;

        [BindProperty]public List<CSV_Organization>? csvOrg { get; set; }
        public OrgFromCSVModel(ICommonRepo commonRepo, IUserRepo userRepo, IOrganizationRepo organizationRepo, IMapper mapper)
        {
            _CommonRepo = commonRepo;
            _UserRepo = userRepo;
            _OrganizationRepo = organizationRepo;
            _mapper = mapper;
        }
        public async Task OnGet()
        {
            if (!CSVManager.CheckCSVFile("organizations"))
            {
                csvOrg = null;
            }
            else
            {                
                csvOrg = await CSVManager.ReadFromCSV<CSV_Organization>();
            }
        }
        public async Task OnPost()
        {
            if (!CSVManager.CheckCSVFile("organizations"))
            {
                csvOrg = null;
            }
            else
            {
                csvOrg = await CSVManager.ReadFromCSV<CSV_Organization>();
            }

            string have = String.Empty;
            List<Organization> organizations = await _OrganizationRepo.GetOrganizations();

            foreach (var csv_org in csvOrg)
            {
                bool exist = organizations.Exists(u => u.INN_ORG == csv_org.INN_ORG_Reader);
                if (!exist)
                {
                    Organization orgForAdd = _mapper.Map<CSV_Organization, Organization>(csv_org);
                    await _CommonRepo.AddEntity(orgForAdd);
                }
            }
        }
    }
}
