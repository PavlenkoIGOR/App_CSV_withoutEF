using App_CSV_withoutEF.Data.Models;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Text;

namespace App_CSV_withoutEF.BLL.Services
{
    public struct CSVManager
    {
        private CSV_User userCSV;
        private CSV_Organization organizationCSV;

        //private List<CSV_User> usersCSV;
        //private List<CSV_Organization> organizationsCSV;
        private List<User> usersCSV;
        private List<Organization> organizationsCSV;

        public CSVManager(CSV_User cSV_User, CSV_Organization cSV_Organization)
        {
            userCSV = cSV_User;
            organizationCSV = cSV_Organization;
        }
        //public Reader(List<CSV_User> users, List<CSV_Organization> organizations)
        //{
        //    usersCSV = users;
        //    organizationsCSV = organizations;
        //}
        public CSVManager(List<User> users, List<Organization> organizations)
        {
            usersCSV = users;
            organizationsCSV = organizations;
        }


        public static async Task WritoToCSV<T>(List<T> entity)
        {
            string folder = Path.Combine("C:\\", "CSV");
            DirectoryInfo di = new DirectoryInfo(folder);
            if (!di.Exists)
            {
                di.Create();
            }

            string csvFilePath = ""; 
            if (entity is List<CSV_User>)
            {
                csvFilePath = Path.Combine(folder, "users.csv");                
                using (StreamWriter sw = new StreamWriter(csvFilePath, false, Encoding.GetEncoding("windows-1251")))
                {
                    CsvConfiguration csvConf = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
                    {
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
                csvFilePath = Path.Combine(folder, "organizations.csv");
                using (StreamWriter sw = new StreamWriter(csvFilePath, false, Encoding.GetEncoding("windows-1251")))
                {
                    CsvConfiguration csvConf = new CsvConfiguration(CultureInfo.GetCultureInfo("ru-RU"))
                    {
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
    }
}
