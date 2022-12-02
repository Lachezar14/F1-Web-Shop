using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Data_Layer.Entities;
using Models;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Data_Layer.DBConnections
{
    public class UserDB : IUserDB
    {
        string conn = "server=studmysql01.fhict.local;database=dbi477927;uid=dbi477927;pwd=root";

        public User GetUser(int id)
        {
            string query = $"SELECT * FROM users WHERE Id = @id ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                    User user = new (
                    
                        myReader.GetInt32("id"),
                        myReader.GetString("FirstName"),
                        myReader.GetString("LastName"),
                        myReader.GetString("Email"),
                        myReader.GetString("PhoneNumber"),
                        myReader.GetString("Address"),
                        myReader.GetString("City"),
                        myReader.GetString("Postcode"),
                        myReader.GetString("Type"),
                        myReader.GetString("Username"),
                        myReader.GetString("Password")
                    );
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                myConn.Close();
            }
        }

        public List<User> GetAllUsers()
        {
            string query = "SELECT * FROM users ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            List<User> users = new List<User>();

            try
            {
                myConn.Open();
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    User user = new(

                        myReader.GetInt32("id"),
                        myReader.GetString("FirstName"),
                        myReader.GetString("LastName"),
                        myReader.GetString("Email"),
                        myReader.GetString("PhoneNumber"),
                        myReader.GetString("Address"),
                        myReader.GetString("City"),
                        myReader.GetString("Postcode"),
                        myReader.GetString("Type"),
                        myReader.GetString("Username"),
                        myReader.GetString("Password")
                    );
                    users.Add(user);
                }
                return users;
            }
            finally
            {
                myConn.Close();
            }
        }



        public void InsertAdmin(User user)
        {
            string query = "INSERT INTO users(FirstName,LastName,Email,PhoneNumber,Address,City,Postcode,Type,Username,Password) VALUES (@FirstName,@LastName,@Email,@PhoneNumber,@Address,@City,@Postcode,@Type,@Username,@Password);";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@FirstName", user.FName);
                command.Parameters.AddWithValue("@LastName", user.LName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PhoneNumber", user.Phone);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@City", user.City);
                command.Parameters.AddWithValue("@Postcode", user.Postcode);
                command.Parameters.AddWithValue("@Type", "Admin");
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                myConn.Close();
            }
        }
        public void InsertCustomer(User user)
        {
            string query = "INSERT INTO users(FirstName,LastName,Email,PhoneNumber,Address,City,Postcode,Type,Username,Password) VALUES (@FirstName,@LastName,@Email,@PhoneNumber,@Address,@City,@Postcode,@Type,@Username,@Password);";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@FirstName", user.FName);
                command.Parameters.AddWithValue("@LastName", user.LName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PhoneNumber", user.Phone);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@City", user.City);
                command.Parameters.AddWithValue("@Postcode", user.Postcode);
                command.Parameters.AddWithValue("@Type", "Customer");
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                myConn.Close();
            }
        }

        public void UpdateUser(User user)
        {
            string query = $"UPDATE users SET FirstName = @FirstName,LastName = @LastName,Email = @Email,PhoneNumber = @PhoneNumber,Address = @Address,City = @City,Postcode = @Postcode,Type = @Type,Username = @Username,Password = @Password WHERE Id = @Id ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);

            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@FirstName", user.FName);
                command.Parameters.AddWithValue("@LastName", user.LName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PhoneNumber", user.Phone);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@City", user.City);
                command.Parameters.AddWithValue("@Postcode", user.Postcode);
                command.Parameters.AddWithValue("@Type", user.Type);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConn.Close();
            }
        }

        public void DropUser(int id)
        {
            string query = "DELETE FROM users WHERE Id = @id ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConn.Close();
            }
        }
    }
}
