using App_CSV_withoutEF.Data.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Net;
using System.Text;

namespace App_CSV_withoutEF.BLL.Services
{
    public struct CSVManager
    {
        private static string _mainPath = "C:\\";
        private static string _currentFolderName = "CSV";
        private static string _usersSCVFile = "users.csv";
        private static string _orgSCVFile = "organizations.csv";

        /// <summary>
        /// Метод для определения наличия CSV-файла
        /// </summary>
        /// <param name="entity">Название класса-модели</param>
        /// <returns></returns>
        public static bool CheckCSVFile(string entity)
        {
            string file = "";
            string folder = Path.Combine(_mainPath, _currentFolderName);
            DirectoryInfo di = new DirectoryInfo(folder);
            if (!di.Exists)
            {
                return false;
            }
            switch (entity.ToUpper()) 
            {
                case "USERS":
                    file = Path.Combine(folder, _usersSCVFile);
                    break;
                case "ORGANIZATION":
                    file = Path.Combine(folder, _orgSCVFile);
                    break;
            }
            if (!File.Exists(file))
            {
                return false;
            }
            return true;
        }
        public static async Task WritoToCSV<T>(List<T> entity)
        {
            string folder = Path.Combine(_mainPath, _currentFolderName);
            DirectoryInfo di = new DirectoryInfo(folder);
            if (!di.Exists)
            {
                di.Create();
            }

            string csvFilePath = "";
            if (entity is List<CSV_User>)
            {
                csvFilePath = Path.Combine(folder, _usersSCVFile);
                using (StreamWriter sw = new StreamWriter(csvFilePath, false, Encoding.GetEncoding("windows-1251")))
                {
                    CsvConfiguration csvConf = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
                    {
                        HasHeaderRecord = true,
                        Delimiter = ";"
                    };
                    using (CsvWriter csvWriter = new CsvWriter(sw, csvConf))
                    {
                        await csvWriter.WriteRecordsAsync(entity as List<CSV_User>);
                    }
                    sw.Close();
                }
            }

            else if (entity is List<CSV_Organization>)
            {
                csvFilePath = Path.Combine(folder, _orgSCVFile);
                using (StreamWriter sw = new StreamWriter(csvFilePath, false, Encoding.GetEncoding("windows-1251")))
                {
                    CsvConfiguration csvConf = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
                    {
                        HasHeaderRecord = true,
                        Delimiter = ";"
                    };
                    using (CsvWriter csvWriter = new CsvWriter(sw, csvConf))
                    {
                        await csvWriter.WriteRecordsAsync(entity as List<CSV_Organization>);
                    }
                    sw.Close();
                }
            }
        }

        public static async Task<List<T>> ReadFromCSV<T>()
        {
            T obj = default(T);
            List<T> objectsList = new List<T>();
            char[] charsToTrim = { '=', '\"' };
            try
            {
                if (typeof(T) == typeof(CSV_Organization))
                {
                    using (StreamReader srCSV = new StreamReader(Path.Combine(_mainPath, _currentFolderName, _orgSCVFile), Encoding.GetEncoding("windows-1251")))
                    {
                        var csvConf = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
                        {
                            HasHeaderRecord = true,
                            Delimiter = ";"
                        };
                        using (var csv = new CsvReader(srCSV, csvConf))
                        {
                            obj = (T)(object)new CSV_Organization();
                            var record = new CSV_Organization();
                            var records = csv.EnumerateRecords(record);
                            foreach (var item in records)
                            {
                                objectsList.Add((T)(object)new CSV_Organization()
                                {
                                    OrgId_Reader = item.OrgId_Reader,
                                    Title_ORG_Reader = item.Title_ORG_Reader,
                                    INN_ORG_Reader = item.INN_ORG_Reader.Trim(charsToTrim),
                                    UrAddress_ORG_Reader = item.UrAddress_ORG_Reader,
                                    FactAddress_ORG_Reader = item.FactAddress_ORG_Reader
                                });
                            }
                        }
                    }
                }
                else if (typeof(T) == typeof(CSV_User))
                {
                    using (StreamReader srCSV = new StreamReader(Path.Combine(_mainPath, _currentFolderName, _usersSCVFile), Encoding.GetEncoding("windows-1251")))
                    {
                        var csvConf = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
                        {
                            HasHeaderRecord = true,
                            Delimiter = ";"                            
                        };
                        using (var csv = new CsvReader(srCSV, csvConf))
                        {
                            obj = (T)(object)new CSV_User();
                            
                            var record = new CSV_User();
                            var records = csv.EnumerateRecords(record);
                            foreach (var item in records)
                            {
                                objectsList.Add((T)(object)new CSV_User
                                {
                                    UserId_Reader = item.UserId_Reader,
                                    UserName_Reader = item.UserName_Reader,
                                    UserLastname_Reader = item.UserLastname_Reader,
                                    UserSurname_Reader = item.UserSurname_Reader,
                                    BirthDate_Reader = item.BirthDate_Reader,
                                    PassportSerial_Reader = item.PassportSerial_Reader.Trim(charsToTrim),
                                    PassportNumber_Reader = item.PassportNumber_Reader.Trim(charsToTrim),
                                    UserOrganizationId_Reader = item.UserOrganizationId_Reader
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return objectsList;
        }
    }
}
