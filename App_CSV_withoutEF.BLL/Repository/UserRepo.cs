using App_CSV_withoutEF.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace App_CSV_withoutEF.BLL.Repository
{
    public interface IUserRepo
    {
        public int AddUser(User user);
    }

    public class UserRepo : IUserRepo
    {
        public UserRepo()
        {                
        }

        
    }
}
