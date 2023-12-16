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
    public class DonorRepository : BaseRepository, IDonorRepository
    {
        //Constructor
        public DonorRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        //Methods
        public void Add(DonorModel donorModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into Donor values (@name, @email, @phoneNumber)";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = donorModel.Name;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = donorModel.Email;
                command.Parameters.Add("@phoneNumber", SqlDbType.NVarChar).Value = donorModel.PhoneNumber;
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
                command.CommandText = "delete from Donor where Donor_Id=@id";
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;           
                command.ExecuteNonQuery();
            }
        }
        public void Edit(DonorModel donorModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update Donor 
                                        set Donor_Name=@name,Donor_Email= @email,Donor_PhoneNumber= @phoneNumber 
                                        where Donor_Id=@id";
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = donorModel.Name;
                command.Parameters.Add("@email", SqlDbType.NVarChar).Value = donorModel.Email;
                command.Parameters.Add("@phoneNumber", SqlDbType.NVarChar).Value = donorModel.PhoneNumber;
                command.Parameters.Add("@id", SqlDbType.Int).Value = donorModel.Id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DonorModel> GetAll()
        {
            var donorList = new List<DonorModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from Donor order by Donor_Id desc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var donorModel = new DonorModel();
                        donorModel.Id = (int)reader[0];
                        donorModel.Name = reader[1].ToString();
                        donorModel.Email = reader[2].ToString();
                        donorModel.PhoneNumber = reader[3].ToString();
                        donorList.Add(donorModel);
                    }
                }
            }
            return donorList;
        }

        public IEnumerable<DonorModel> GetByValue(string value)
        {
            var donorList = new List<DonorModel>();
            int donorId = int.TryParse(value, out _) ? Convert.ToInt32(value) : 0;
            string donorName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select *from Donor
                                        where Donor_Id=@id or Donor_Name like @name+'%' 
                                        order by Donor_Id desc";
                command.Parameters.Add("@id", SqlDbType.Int).Value = donorId;
                command.Parameters.Add("@name", SqlDbType.NVarChar).Value = donorName;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var donorModel = new DonorModel();
                        donorModel.Id = (int)reader[0];
                        donorModel.Name = reader[1].ToString();
                        donorModel.Email = reader[2].ToString();
                        donorModel.PhoneNumber = reader[3].ToString();
                        donorList.Add(donorModel);
                    }
                }
            }
            return donorList;
        }
    }
}
