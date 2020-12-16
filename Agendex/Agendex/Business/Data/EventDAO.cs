using Agendex.Controllers;
using Agendex.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Agendex.Business.Data
{
    public class EventDAO : IEventDAO
    {
        private string connectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Collin\Dropbox\GCU\Year 3\Fall 2020\CST-326\Agendex\Agendex\Agendex\App_Data\Agendex.mdf;Integrated Security=True";

        public bool AuthenticateConfirmedEvent(Event e)
        {
            bool success = false;
            string queryString = "SELECT * FROM dbo.CONFIRMED_EVENTS WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = e.ID;
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
                catch (Exception ex) { Debug.WriteLine(ex.Message); }
            }
            return success;
        }

        public bool AuthenticateEvent(Event e)
        {
            bool success = false;
            string queryString = "SELECT * FROM dbo.EVENTS WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = e.ID;
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
                catch (Exception ex) { Debug.WriteLine(ex.Message); }
            }
            return success;
        }

        public bool ConfirmEvent(Event e)
        {
            bool success = false;

            string queryString = "INSERT INTO dbo.CONFIRMED_EVENTS (Type, EventName, Description, StartDate, EndDate, CompanyId) VALUES (@Type, @EventName, @Description, @Start, @End, @CompanyId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Type", e.Type);
                command.Parameters.AddWithValue("@EventName", e.EventName);
                command.Parameters.AddWithValue("@Description", e.EventDescription);
                command.Parameters.AddWithValue("@Start", e.StartDate);
                command.Parameters.AddWithValue("@End", e.EndDate);
                command.Parameters.AddWithValue("@CompanyId", e.CompanyId);

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

        public bool DeleteConfirmedEvent(int id)
        {
            bool success = false;

            string queryString = "DELETE FROM dbo.CONFIRMED_EVENTS WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    Console.WriteLine("Error Deleting");
                }
                else
                {
                    success = true;
                }
            }

            return success;
        }

        public bool DeleteEvent(int id)
        {
            bool success = false;

            string queryString = "DELETE FROM dbo.EVENTS WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                int result = command.ExecuteNonQuery();

                if (result < 0)
                {
                    Console.WriteLine("Error Deleting");
                }
                else
                {
                    success = true;
                }
            }

            return success;
        }

        public bool SubmitEvent(Models.Event e)
        {

            bool success = false;

            string queryString = "INSERT INTO dbo.EVENTS (Type, EventName, Description, StartDate, EndDate, CompanyId) VALUES (@Type, @EventName, @Description, @StartDate, @EndDate, @CompanyId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Type", e.Type);
                command.Parameters.AddWithValue("@EventName", e.EventName);
                command.Parameters.AddWithValue("@Description", e.EventDescription);
                command.Parameters.AddWithValue("@StartDate", e.StartDate);
                command.Parameters.AddWithValue("@EndDate", e.EndDate);
                command.Parameters.AddWithValue("@CompanyId", e.CompanyId);

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

        public bool CompanySubmitEvent(Models.Event e)
        {

            bool success = false;

            string queryString = "INSERT INTO dbo.CONFIRMED_EVENTS (Type, EventName, Description, StartDate, EndDate, CompanyId) VALUES (@Type, @EventName, @Description, @StartDate, @EndDate, @CompanyId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Type", e.Type);
                command.Parameters.AddWithValue("@EventName", e.EventName);
                command.Parameters.AddWithValue("@Description", e.EventDescription);
                command.Parameters.AddWithValue("@StartDate", e.StartDate);
                command.Parameters.AddWithValue("@EndDate", e.EndDate);
                command.Parameters.AddWithValue("@CompanyId", e.CompanyId);

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

        public List<Event> GetRequestedEvents(Company c)
        {
            bool success = false;
            List<Event> eventList = new List<Event>();

            string queryString = "SELECT * FROM dbo.EVENTS WHERE CompanyId = @CompanyId";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@CompanyId", c.ID);
                    try 
                    {
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        { 
                            Event e = new Event();
                            e.ID = sqlDataReader.GetInt32(0);
                            e.Type = sqlDataReader.GetString(1);
                            e.EventName = sqlDataReader.GetString(2);
                            e.EventDescription = sqlDataReader.GetString(3);
                            e.StartDate = sqlDataReader.GetString(4);
                            e.EndDate = sqlDataReader.GetString(5);
                            e.CompanyId = sqlDataReader.GetInt32(6);

                            eventList.Add(e);
                        }
                        sqlDataReader.Close();
                        sqlConnection.Close();
                        success = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Failue!");
                        Debug.WriteLine(e.Message);
                    }
                }
            }

            return eventList;
        }

        public Event EventFromId(int id)
        {
            Event e = new Event();
            
            string queryString = "SELECT * FROM dbo.EVENTS WHERE Id = @Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;
                try
                {
                    connection.Open();
                    Debug.WriteLine("in here");
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        e.ID = id;
                        e.Type = reader.GetString(1);
                        e.EventName = reader.GetString(2);
                        e.EventDescription = reader.GetString(3);
                        e.StartDate = reader.GetString(4);
                        e.EndDate = reader.GetString(5);
                        e.CompanyId = reader.GetInt32(6);
                    }
                    reader.Close();
                }
                catch (Exception ex) { Debug.WriteLine(ex.Message); }
            }
            return e;
        }
    }
}