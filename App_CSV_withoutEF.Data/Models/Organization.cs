using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CSV_withoutEF.Data.Models
{
    public class Organization
    {
        public int OrgId { get; set; }
        public string Title_ORG { get; set; }
        public string INN_ORG { get; set; }
        public string UrAddress_ORG { get; set; }
        public string FactAddress_ORG { get;set; }
    }
}