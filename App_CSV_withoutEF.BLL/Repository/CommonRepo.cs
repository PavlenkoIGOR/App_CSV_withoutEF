using App_CSV_withoutEF.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace App_CSV_withoutEF.BLL.Repository
{
    public interface ICommonRepo
    {
        public Task<int> AddEntity(Object entity);
    }

    public class CommonRepo : ICommonRepo
    {
        private IConfiguration _conf;
        public CommonRepo(IConfiguration conf)
        {
            _conf = conf;
        }

        public async Task<int> AddEntity(Object entity)
        {
            int entityId = 0;

            string connectionString = _conf.GetConnectionString("ConnectToWebApp_toCSV_DB");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    if (entity is User)
                    {
                        string[] roles = { "administrator", "moderator", "user" };
                        command.CommandText = "INSERT INTO users (username, userlastname, usersurname, userbirthdate, passportserial, passportnumber, organization_id) OUTPUT INSERTED.id VALUES (@username, @userlastname, @usersurname, @userbirthdate, @passportserial, @passportnumber, @organization_id)";
                        command.Parameters.AddWithValue("@username", (entity as User).UserName);
                        command.Parameters.AddWithValue("@userlastname", (entity as User).UserLastname);
                        command.Parameters.AddWithValue("@usersurname", (entity as User).UserSurname);
                        command.Parameters.AddWithValue("@userbirthdate", (entity as User).BirthDate);
                        command.Parameters.AddWithValue("@passportserial", (entity as User).PassportSerial);
                        command.Parameters.AddWithValue("@passportnumber", (entity as User).PassportNumber);
                        command.Parameters.AddWithValue("@organization_id", (entity as User).UserOrganizationId);

                        entityId = (int)(command.ExecuteScalar());
                    }
                    //await command.ExecuteNonQueryAsync();
                    if (entity is Organization)
                    {
                        command.CommandText = "INSERT INTO organizations (title, inn, uradress, factaddress) OUTPUT INSERTED.id VALUES (@title, @inn, @uradress, @factaddress)";
                        command.Parameters.AddWithValue("@title", (entity as Organization).Title_ORG);
                        command.Parameters.AddWithValue("@inn", (entity as Organization).INN_ORG);
                        command.Parameters.AddWithValue("@uradress", (entity as Organization).UrAddress_ORG);
                        command.Parameters.AddWithValue("@factaddress", (entity as Organization).FactAddress_ORG);

                        entityId = (int)(command.ExecuteScalar());
                    }
                }
                await connection.CloseAsync();
            }
            return entityId;
        }

        
    }
}
