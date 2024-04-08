using App_CSV_withoutEF.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace App_CSV_withoutEF.BLL.Repository
{
    public interface IUserRepo
    {
        public User GetUserByEmail(string email);
        public Task<List<User>> GetUsers();
    }

    public class UserRepo : IUserRepo
    {
        private IConfiguration _conf;
        public UserRepo(IConfiguration conf)
        {
            _conf = conf;
        }

        public User GetUserByEmail(string email)
        {
            string connectionString = _conf.GetConnectionString("ConnectToWebApp_toCSV_DB");
            User user = new User();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectUserByEmail = "select * from users where email = @email";
                using (SqlCommand command = new SqlCommand(selectUserByEmail, connection))
                {
                    command.Parameters.AddWithValue("@email", email);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user.UserId = reader.GetInt32(0);//id
                            user.UserName = reader.GetString(1);//Name
                            user.UserLastname = reader.GetString(2);//UserLastname                            
                            user.UserSurname = reader.GetString(3);//UserSurname
                            user.BirthDate = reader.GetDateTime(4);//BirthDate
                            user.PassportSerial = reader.GetInt32(5);//PassportSerial
                            user.PassportNumber = reader.GetInt32(6);//PassportNumber
                            user.UserOrganizationId = reader.GetInt32(7);//UserOrganizationId
                        }
                        reader.CloseAsync();
                    }
                }
                connection.CloseAsync();
            }
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            string connectionString = _conf.GetConnectionString("ConnectToWebApp_toCSV_DB");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectUserByEmail = "select * from users";
                using (SqlCommand command = new SqlCommand(selectUserByEmail, connection))
                {
                    //command.Parameters.AddWithValue("@email", email);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User()
                            {
                                UserId = reader.GetInt32(0),//id
                                UserName = reader.GetString(1),//Name
                                UserLastname = reader.GetString(2),//UserLastname                            
                                UserSurname = reader.GetString(3),//UserSurname
                                BirthDate = reader.GetDateTime(4),//BirthDate
                                PassportSerial = reader.GetInt32(5),//PassportSerial
                                PassportNumber = reader.GetInt32(6),//PassportNumber
                                UserOrganizationId = reader.GetInt32(7),//UserOrganizationId
                            };
                            users.Add(user);
                        }
                        await reader.CloseAsync();
                    }
                }
                await connection.CloseAsync();
            }
            return users;
        }
    }
}
