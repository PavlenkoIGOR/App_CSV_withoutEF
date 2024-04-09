using App_CSV_withoutEF.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_CSV_withoutEF.BLL.Repository
{
    public interface IOrganizationRepo
    {
        public Task<Organization> GetOrganizationByTitle(string t);
        public Task<List<Organization>> GetOrganizations();
    }

    public class OrganizationRepo : IOrganizationRepo
    {
        private IConfiguration _conf;
        public OrganizationRepo(IConfiguration configuration)
        {
            _conf = configuration;
        }

        public async Task<Organization> GetOrganizationByTitle(string t)
        {
            Organization org = new Organization();
            string connectionString = _conf.GetConnectionString("ConnectToWebApp_toCSV_DB");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectUserByEmail = "select * from organizations where title = @title";
                using (SqlCommand command = new SqlCommand(selectUserByEmail, connection))
                {
                    command.Parameters.AddWithValue("@title", t);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            org.OrgId = reader.GetInt32(0);//id
                            org.Title_ORG = reader.GetString(1);//Title_ORG
                            org.INN_ORG = reader.GetString(2);//INN_ORG                            
                            org.UrAddress_ORG = reader.GetString(3);//UrAddress_ORG
                            org.FactAddress_ORG = reader.GetString(3);//FactAddress_ORG
                        }
                        await reader.CloseAsync();
                    }
                }
                await connection.CloseAsync();
            }
            return org;
        }

        public async Task<List<Organization>> GetOrganizations()
        {
            List<Organization> organizations = new List<Organization>();
            string connectionString = _conf.GetConnectionString("ConnectToWebApp_toCSV_DB");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                string selectUserByEmail = "select * from organizations";
                using (SqlCommand command = new SqlCommand(selectUserByEmail, connection))
                {
                    //command.Parameters.AddWithValue("@email", email);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (await reader.ReadAsync())
                        {
                            Organization org = new Organization()
                            {
                                OrgId = reader.GetInt32(0),//id
                                Title_ORG = reader.GetString(1),//Title_ORG
                                INN_ORG = reader.GetString(2),//INN_ORG                            
                                UrAddress_ORG = reader.GetString(3),//UrAddress_ORG                                
                                FactAddress_ORG = reader.GetString(3),//FactAddress_ORG                                
                            };
                            organizations.Add(org);
                        }
                        await reader.CloseAsync();
                    }
                }
                await connection.CloseAsync();
            }
            return organizations;
        }
    }
}
