using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CRUDWinFormsMVP.Models;

namespace CRUDWinFormsMVP._Repositories
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        //Constructor
        public EventRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //Methods
        public void Add(EventModel eventModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Event values (@name, @type, @colour)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = eventModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = eventModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = eventModel.Description;
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from Event where Event_Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;           
                command.ExecuteNonQuery();
            }
        }
        public void Edit(EventModel eventModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Event 
                                        set Event_Name=@name,Event_Type= @type,Event_Colour= @colour 
                                        where Event_Id=@id";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = eventModel.Name;
                command.Parameters.Add("@type", SqlDbType.NVarChar).Value = eventModel.Type;
                command.Parameters.Add("@colour", SqlDbType.NVarChar).Value = eventModel.Description;
                command.Parameters.Add("@id", SqlDbType.Int).Value = eventModel.Id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<EventModel> GetAll()
        {
            var eventList = new List<EventModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Event order by Event_Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var eventModel = new EventModel();
                        eventModel.Id = (int)reader[0];
                        eventModel.Name = reader[1].ToString();
                        eventModel.Type = reader[2].ToString();
                        eventModel.Description = reader[3].ToString();
                        eventList.Add(eventModel);
                    }
                }
            }
            return eventList;
        }

        public IEnumerable<EventModel> GetByValue(string value)
        {
            var eventList = new List<EventModel>();
            int eventId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string eventName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select *from Event
                                        where Event_Id=@id or Event_Name like @name+'%' 
                                        order by Event_Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = eventId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = eventName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var eventModel = new EventModel();
                        eventModel.Id = (int)reader[0];
                        eventModel.Name = reader[1].ToString();
                        eventModel.Type = reader[2].ToString();
                        eventModel.Description = reader[3].ToString();
                        eventList.Add(eventModel);
                    }
                }
            }
            return eventList;
        }
    }
}
