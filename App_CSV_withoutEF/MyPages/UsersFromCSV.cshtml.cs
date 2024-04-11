using App_CSV_withoutEF.BLL.Repository;
using App_CSV_withoutEF.BLL.Services;
using App_CSV_withoutEF.Data.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace App_CSV_withoutEF.MyPages
{
    public class UsersFromCSVModel : PageModel
    {
        private ICommonRepo _CommonRepo;
        private IUserRepo _UserRepo;
        private IOrganizationRepo _OrganizationRepo;
        private IMapper _mapper;

        [BindProperty] public List<CSV_User> csv_Users { get; set; }
        public UsersFromCSVModel(ICommonRepo commonRepo, IUserRepo userRepo, IOrganizationRepo organizationRepo, IMapper mapper)
        {
            _CommonRepo = commonRepo;
            _UserRepo = userRepo;
            _OrganizationRepo = organizationRepo;
            _mapper = mapper;
        }
        public async Task OnGet()
        {
            if (!CSVManager.CheckCSVFile("users"))
            {
                csv_Users = null;
            }
            else
            {
                csv_Users = await CSVManager.ReadFromCSV<CSV_User>();
            }
        }

        public async Task OnPost()
        {
            if (!CSVManager.CheckCSVFile("users"))
            {
                csv_Users = null;
            }
            else
            {
                csv_Users = await CSVManager.ReadFromCSV<CSV_User>();
            }


            string have = String.Empty;
            List<User> users = await _UserRepo.GetUsers();



            foreach (var csv_user in csv_Users)
            {
                bool exist = users.Exists(
                    u => u.PassportSerial == csv_user.PassportSerial_Reader
                    &&
                    u.PassportNumber == csv_user.PassportNumber_Reader);
                if (!exist)
                {
                    User userForAdd = _mapper.Map<CSV_User, User>(csv_user);
                    await _CommonRepo.AddEntity(userForAdd);
                }
            }

        }
    }
}
