using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CSV_withoutEF.BLL.Services
{
    public class CSV_Organization
    {
        [Name("Код организации")]
        public int OrgId_Reader { get; set; }

        [Name("Название организации")]
        public string Title_ORG_Reader { get; set; }

        [Name("Код организации")]
        public string INN_ORG_Reader { get; set; }

        [Name("Юридический адрес организации")]
        public string UrAddress_ORG_Reader { get; set; }

        [Name("Фактический адрес организации")]
        public string FactAddress_ORG_Reader { get; set; }
    }
}
