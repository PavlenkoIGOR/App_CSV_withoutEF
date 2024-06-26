﻿using CsvHelper.Configuration.Attributes;
using CsvHelper.TypeConversion;

namespace App_CSV_withoutEF.BLL.Services
{
    public class CSV_Organization
    {
        [Name("Код организации")]
        public int? OrgId_Reader { get; set; }

        [Name("Название организации")]
        public string? Title_ORG_Reader { get; set; }

        [Ignore]
        [TypeConverter(typeof(StringConverter))]
        public string? INN_ORG_Reader { get; set; }

        [Name("ИНН организации")]
        public string? INN_ORG_Convert_Reader { get { return $"=\"{INN_ORG_Reader}\""; } set { INN_ORG_Reader = value; } }

        [Name("Юридический адрес организации")]
        public string? UrAddress_ORG_Reader { get; set; }

        [Name("Фактический адрес организации")]
        public string? FactAddress_ORG_Reader { get; set; }
    }
}
