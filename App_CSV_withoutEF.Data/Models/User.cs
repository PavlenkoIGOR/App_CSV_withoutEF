using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CSV_withoutEF.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserLastname { get; set; }
        public string UserSurname { get; set; }
        public DateTime BirthDate { get; set; }
        public int PassportSerial { get; set; }
        public int PasportNumber { get; set; }
        public Organization UserOrganization { get; set; }
    }
}
