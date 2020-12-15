using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Agendex.Business.Data
{
    public class SecurityDAO : ISecurityDAO
    {
        private string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\derek\Documents\GitHub\Agendex\Agendex\Agendex\App_Data\Agendex.mdf;Integrated Security=True";

        public bool AuthenticateUserInDB(Models.User user)
        {
            bool success = false;
            Debug.WriteLine(user.Email);
            Debug.WriteLine(user.Password);
            string queryString = "SELECT * FROM dbo.USERS WHERE Email = @email and Password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 50).Value = user.Email;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
                try
                {
                    connection.Open();
                    Debug.WriteLine("in here");
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return success;
        }

        public Models.User ReturnUserFromDB(Models.User user)
        {
            string queryString = "SELECT * FROM dbo.USERS WHERE Email = @Email and Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Models.User returnedUser = new Models.User();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 50).Value = user.Email;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = user.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            returnedUser.ID = reader.GetInt32(0);
                            returnedUser.FirstName = reader.GetString(3);
                            returnedUser.LastName = reader.GetString(4);
                            returnedUser.Email = reader.GetString(1);
                            returnedUser.Password = reader.GetString(2);
                            returnedUser.CompanyId = reader.GetInt32(5);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return returnedUser;
            }
        }

        public int FetchAssociatedCompanyID(Models.User user)
        {
            int CompanyID = -1;
            string queryString = "SELECT CompanyId FROM dbo.USERS WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = user.ID;
                try
                {
                    connection.Open();
                    Debug.WriteLine("in here");
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        CompanyID = reader.GetInt32(5);
                    }
                    reader.Close();
                }
                catch (Exception e) { Debug.WriteLine(e.Message); }
            }

            return CompanyID;
        }

        public bool AuthenticateCompanyInDB(Models.Company company)
        {
            bool success = false;
            Debug.WriteLine(company.CompanyEmail);
            Debug.WriteLine(company.Password);
            string queryString = "SELECT * FROM dbo.COMPANIES WHERE CompanyEmail = @email and Password = @password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@email", System.Data.SqlDbType.VarChar, 50).Value = company.CompanyEmail;
                command.Parameters.Add("@password", System.Data.SqlDbType.VarChar, 50).Value = company.Password;
                try
                {
                    connection.Open();
                    Debug.WriteLine("in here");
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        success = true;
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }
            return success;
        }

        public Models.Company ReturnCompanyFromDB(Models.Company company)
        {
            string queryString = "SELECT * FROM dbo.COMPANIES WHERE CompanyEmail = @Email and Password = @Password";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Models.Company returnedCompany = new Models.Company();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Email", System.Data.SqlDbType.VarChar, 50).Value = company.CompanyEmail;
                command.Parameters.Add("@Password", System.Data.SqlDbType.VarChar, 50).Value = company.Password;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            returnedCompany.ID = reader.GetInt32(0);
                            returnedCompany.CompanyEmail = reader.GetString(1);
                            returnedCompany.Password = reader.GetString(2);
                            returnedCompany.CompanyName = reader.GetString(3);
                        }
                    }
                    reader.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return returnedCompany;
            }
        }

        public bool RegisterUser(Models.User user)
        {
            bool success = false;

            string queryString = "INSERT INTO dbo.USERS (Email, Password, FirstName, LastName, CompanyId) VALUES (@Email, @Password, @FirstName, @LastName, @CompanyId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@CompanyId", user.CompanyId);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    Console.WriteLine("Error inserting");
                }
                else
                {
                    success = true;
                }
            }

            return success;
        }

        public bool RegisterCompany(Models.Company company)
        {
            Random rnd = new Random();
            
            bool success = false;

            string queryString = "INSERT INTO dbo.COMPANIES (Id, CompanyEmail, Password, CompanyName) VALUES (@Id, @CompanyEmail, @Password, @CompanyName)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", rnd.Next(100000, 99999999));
                command.Parameters.AddWithValue("@CompanyEmail", company.CompanyEmail);
                command.Parameters.AddWithValue("@Password", company.Password);
                command.Parameters.AddWithValue("@CompanyName", company.CompanyName);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    Console.WriteLine("Error inserting");
                }
                else
                {
                    success = true;
                }
            }

            return success;
        }

    }
}