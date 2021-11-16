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
            else if(adminUsername == user.Username && adminPassword == user.Password)
            {
                if (Database.DeleteUser(user.Id)) return true;
            }

            return false;
        }
    }
}
