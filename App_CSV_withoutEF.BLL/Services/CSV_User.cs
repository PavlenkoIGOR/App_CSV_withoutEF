using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CSV_withoutEF.BLL.Services
{
    public struct CSV_User
    {
        [Name("Позиция товара")]
        public int UserId_Reader { get; set; }
        
        [Name("Имя")]
        public string UserName_Reader { get; set; }

        [Name("Фамилия")]
        public string UserLastname_Reader { get; set; }

        [Name("Отчество")]
        public string UserSurname_Reader { get; set; }

        [Name("Дата рождения")]
        public DateTime BirthDate_Reader { get; set; }

        [Name("Паспорт серия")]
        public int PassportSerial_Reader { get; set; }

        [Name("Паспорт номер")]
        public int PassportNumber_Reader { get; set; }

        [Name("Код организации")]
        public int UserOrganizationId_Reader { get; set; }
    }
}
