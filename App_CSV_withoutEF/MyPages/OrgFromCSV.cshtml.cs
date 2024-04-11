using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.BLL.Services;
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

        public IEnumerable<CSV_Organization> csvOrg { get; set; }
        public OrgFromCSVModel(ICommonRepo commonRepo, IUserRepo userRepo, IOrganizationRepo organizationRepo, IMapper mapper)
        {
            _CommonRepo = commonRepo;
            _UserRepo = userRepo;
            _OrganizationRepo = organizationRepo;
            _mapper = mapper;
            csvOrg = null;
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

        }
    }
}
