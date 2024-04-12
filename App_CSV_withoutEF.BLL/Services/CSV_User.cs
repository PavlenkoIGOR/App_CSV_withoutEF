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

        [Ignore]
        [TypeConverter(typeof(StringConverter))]
        public string? PassportSerial_Reader { get; set; }

        [Name("Паспорт серия")]
        
        public string? PassportSerialConvert_Reader { get { return $"=\"{PassportSerial_Reader}\""; } set { PassportSerial_Reader = value; } }

        [Ignore]
        [TypeConverter(typeof(StringConverter))]
        public string? PassportNumber_Reader { get; set; }

        [Name("Паспорт номер")]
        
        public string? PassportNumberConvert_Reader { get { return $"=\"{PassportNumber_Reader}\""; } set { PassportNumber_Reader = value; } }

        [Name("Код организации")]
        public int? UserOrganizationId_Reader { get; set; }
    }
}
