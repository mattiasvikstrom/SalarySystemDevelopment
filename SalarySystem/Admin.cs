﻿using System;
using System.Collections.Generic;

namespace SalarySystem_API
{
    /// <summary>
    /// Id = "#1"
    /// First name = Admin1
    /// Surname = Admin1
    /// Username = Admin1
    /// Password = Password1234
    /// </summary>
    public class Admin : AbstractUser, IAdmin
    {
        public new string Id { get; set; } = "#1";
        public new bool IsAdmin { get; set; } = true;
        public new string FirstName { get; set; } = "Admin1";
        public new string Surname { get; set; } = "Admin1";
        public new string Username { get; set; } = "Admin1";
        public new string Password { get; set; } = "Password1234";

        public User CreateUser(string id, string firstName, string surname, string username, string password)
        {
            try
            {
                var user = new User
                {
                    Id = id,
                    FirstName = firstName,
                    Surname = surname,
                    Username = username,
                    Password = password
                };

                Database.SaveUser(user);
                Database.Start();
                return user;
            }
            catch(Exception e)
            {
                Console.Clear();
                Console.WriteLine("ERROR" + e);
                return null;
            }
        }
               
        public IEnumerable<IUser> GetUsers()
        {
            return Database.GetUsers();
        }
    }
}