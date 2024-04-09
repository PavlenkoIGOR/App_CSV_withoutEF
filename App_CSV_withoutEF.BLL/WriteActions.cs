namespace App_CSV_withoutEF.BLL
{
    public static class WriteActions
    {
        public static async Task CreateCSVFolder(string fileName)
        {
            string logFolder = Path.Combine("C:\\Users\\Professional\\Desktop", "CSV");
            DirectoryInfo di = new DirectoryInfo(logFolder);
            if (!di.Exists)
            {
                di.Create();
            }
            string logFile = Path.Combine(logFolder, $"{fileName}.txt");
            using (StreamWriter fs = new(logFile, true))
            {
                //await fs.WriteLineAsync($"{action}");
                fs.Close();
            }
        }
    }
}
