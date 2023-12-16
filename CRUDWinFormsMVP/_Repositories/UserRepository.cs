using CRUDWinFormsMVP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDWinFormsMVP._Repositories
{
    internal class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public bool Login(UserModel userModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(*) FROM users WHERE email = @n AND password = @p";
                command.Parameters.Add("@n", SqlDbType.NVarChar).Value = userModel.Email;
                command.Parameters.Add("@p", SqlDbType.NVarChar).Value = userModel.Password;

                // Execute the query and get the result
                int count = (int)command.ExecuteScalar();

                // If count > 0, user exists; otherwise, user doesn't exist
                bool userExists = count > 0;

                return userExists;
            }
        }

    }
}
