using App_CSV_withoutEF.Data.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace App_CSV_withoutEF.BLL.Repository
{
    public class CommonRepo
    {
        private IConfiguration _conf;
        public CommonRepo(IConfiguration conf)
        {
            _conf = conf;
        }

        public int AddEntity(Object entity)
        {
            int entityId = 0;

            string connectionString =  .GetConnectionString("ConnectToforRazorDB");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    if (entity is User)
                    {
                        string[] roles = { "administrator", "moderator", "user" };
                        command.CommandText = "INSERT INTO Users (name, age, email, password, role, registration_date) OUTPUT INSERTED.id VALUES (@name, @age, @email, @password, @role, @registration_date)";
                        command.Parameters.AddWithValue("@name", (entity as User).UserName);
                        command.Parameters.AddWithValue("@age", (entity as User).UserAge);
                        command.Parameters.AddWithValue("@email", (entity as User).UserEmail);
                        command.Parameters.AddWithValue("@password", (entity as User).Password);
                        command.Parameters.AddWithValue("@role", roles[1]);
                        command.Parameters.AddWithValue("@registration_date", DateTime.UtcNow);

                        entityId = (int)(command.ExecuteScalar());
                    }
                    //await command.ExecuteNonQueryAsync();
                    if (entity is Store)
                    {
                        command.CommandText = "INSERT INTO Stores (title, address, startServiceTime, finishServiceTime, email) OUTPUT INSERTED.id VALUES (@title, @address, @startServiceTime, @finishServiceTime, @email)";
                        command.Parameters.AddWithValue("@title", (entity as Store).Store_Title.ToUpper());
                        command.Parameters.AddWithValue("@address", (entity as Store).Store_Address.ToUpper());
                        command.Parameters.AddWithValue("@startServiceTime", (entity as Store).Store_StartServiceTime);
                        command.Parameters.AddWithValue("@finishServiceTime", (entity as Store).Store_FinishServiceTime);
                        command.Parameters.AddWithValue("@email", (entity as Store).Store_Email.ToUpper());

                        entityId = (int)(command.ExecuteScalar());
                    }
                    if (entity is Track)
                    {
                        command.CommandText = "INSERT INTO Tracks (title, duration, album_id) OUTPUT INSERTED.id VALUES (@title, @duration, @album_id)";
                        command.Parameters.AddWithValue("@title", (entity as Track).Track_Title.ToUpper());
                        command.Parameters.AddWithValue("@duration", (entity as Track).Track_Duration);
                        command.Parameters.AddWithValue("@album_id", (entity as Track).Album_Id);

                        entityId = (int)(command.ExecuteScalar());
                    }
                    if (entity is Artist)
                    {
                        command.CommandText = "INSERT INTO Artists (artistname) OUTPUT INSERTED.id VALUES (@artistname)";
                        command.Parameters.AddWithValue("@artistname", (entity as Artist).Name.ToUpper());

                        entityId = (int)(command.ExecuteScalar());
                    }
                }
                connection.Close();
            }

            return entityId;
        }
    }
}
