using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CSV_withoutEF.BLL.Repository
{
    internal class CheckConnection
    {
        private IConfiguration _conf;
        public CheckConnection(IConfiguration conf)
        {
            _conf = conf;
        }
        public static async Task<bool> CheckDBAsync(string connectString)
        {
            OleDbConnection myConnection = new OleDbConnection(connectString);
            try
            {
                await myConnection.OpenAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
