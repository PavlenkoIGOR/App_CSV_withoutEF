using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

namespace App_CSV_withoutEF.BLL.Services
{
    public class CSV_User
    {
        [Name("Позиция товара")]
        public int? UserId_Reader { get; set; }
        
        [Name("Имя")]
        public string? UserName_Reader { get; set; }

        [Name("Фамилия")]
        public string? UserLastname_Reader { get; set; }

        [Name("Отчество")]
        public string? UserSurname_Reader { get; set; }

        [Name("Дата рождения")]
        public DateTime? BirthDate_Reader { get; set; }

        [Name("Паспорт серия")]
        [TypeConverter(typeof(StringConverter))]
        public string? PassportSerial_Reader { get; set; }

        [Name("Паспорт номер")]
        [TypeConverter(typeof(StringConverter))]
        public string? PassportNumber_Reader { get; set; }

        [Name("Код организации")]
        public int? UserOrganizationId_Reader { get; set; }
    }
}
