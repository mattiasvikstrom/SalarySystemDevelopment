using System;

namespace SalarySystem_API
{
    public class AbstractUser : IUser
    {
        public string Id { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsLoggedIn { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }

        /// <summary>
        /// Changes the password of a user.
        /// Admin can not change password on its own account.
        /// Admin may change password on another users account.
        /// </summary>
        /// <param name="user">User to change password on.</param>
        /// <param name="username">Username for account.</param>
        /// <param name="oldPassword">Old password for account.</param>
        /// <param name="newPassword">New password for account.</param>
        /// <returns></returns>
        public string ChangePassword(IUser user, string username, string oldPassword, string newPassword)
        {
            try
            {
                newPassword = newPassword.Trim().ToLower();
                if (user.IsAdmin)
                {
                    return "Admin may not change its own password.";
                }

                if (username == user.Username && oldPassword == user.Password && newPassword != "")
                {
                    user.Password = newPassword;
                    if (Database.DeleteUser(user.Id))
                    {
                        if (Database.SaveUser(user))
                        {
                            return user.Password;
                        }
                    }

                    return "Wrong Password";
                }

                return "Wrong Password";
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine();
                return "Error!" + e;
            }
        }

        public bool DeleteAccount(string adminUsername, string adminPassword, IUser user)
        {
            if (user == null) return false;
            else if (adminUsername == "Admin1" && adminPassword == "Password1234")
            {
                if (Database.DeleteUser(user.Id)) return true;
            }
            else if (adminUsername == user.Username && adminPassword == user.Password)
            {
                if (Database.DeleteUser(user.Id)) return true;
            }

            return false;
        }

        public bool EditUser(IUser user, string newFirstName, string newSurname, string newUsername, string newPassword)
        {
            if (user.IsLoggedIn && !user.IsAdmin)
            {
                user.FirstName = newFirstName;
                user.Surname = newSurname;
                user.Username = newUsername;
                user.Password = newPassword;
                Database.DeleteUser(user.Id);
                Database.SaveUser(user);
                return true;
            }
            else if (user.IsLoggedIn && user.IsAdmin)
            {
                user.FirstName = newFirstName;
                user.Surname = newSurname;
                return true;
            }

            return false;
        }

        public string GetRole(IUser user)
        {
            if (user.IsLoggedIn) return user.Role;
            else return "User needs too be logged in to see role";
        }

        public int GetSalary(IUser user)
        {
            if (user.IsLoggedIn) return user.Salary;
            else return 0;
        }

        public bool Login(IUser user, string username, string password)
        {
            if (user.IsLoggedIn) return true;
            else if (!user.IsLoggedIn && user.Username == username && user.Password == password)
            {
                user.IsLoggedIn = true;
                return true;
            }
            else return false;
        }

        public bool Logout(IUser user)
        {
            if (user.IsLoggedIn)
            {
                user.IsLoggedIn = false;
                return true;
            }

            else return false;
        }
    }
}
