//using Data_Layer.Entities;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int Id { get; set; }

        public string FName { get; private set; }

        public string LName { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public string Address { get; private set; }

        public string City { get; private set; }

        public string Postcode { get; private set; }
        
        public string Type { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }
     
        public User(int id,string fName,string lName,string email,string phone,string address,string city,string postcode,string type,string username,string password) 
        {
            Id = id;
            FName = fName;
            LName = lName;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            Postcode = postcode;
            Type = type;
            Username = username;
            Password = password;
        }

        public User(string fName, string lName, string email, string phone, string address, string city, string postcode, string type, string username, string password)
        {
            FName = fName;
            LName = lName;
            Email = email;
            Phone = phone;
            Address = address;
            City = city;
            Postcode = postcode;
            Type = type;
            Username = username;
            Password = password;
        }

        public User(UserDTO uRazor)
        {
            Id = uRazor.Id;
            FName = uRazor.FName;
            LName = uRazor.LName;
            Email = uRazor.Email;
            Phone = uRazor.Phone;
            Address = uRazor.Address;
            City = uRazor.City;
            Postcode = uRazor.Postcode;
            Type = uRazor.Type;
            Username = uRazor.Username;
            Password = uRazor.Password;
        }
        
        public User() 
        {
        }

        public override string ToString()
        {
            return $"ID: {Id} | Name: {FName} {LName} | Phone Number: {Phone} ";
        }


        //Equals method should be overriden to test for equality.
        //By default it will use reference comparison,
        //and since your expected and actual objects are in different locations in memory it will fail.
        public override bool Equals(Object obj)
        {
            if (obj is User)
            {
                var that = obj as User;
                return this.Id == that.Id;
            }
            return false;
        }

    }
}
