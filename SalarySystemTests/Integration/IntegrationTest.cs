using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem_API;

namespace SalarySystem_API.Tests.Integration
{
    [TestClass()]
    public class IntegrationTest
    {
        [TestMethod()]
        public void AdminTest()
        {
            Database.Start();
            var admin = new Admin();
            //var newPassword = admin.ChangePassword(admin, "Admin1", "Password1234", "NewPassword123");

            //login
            admin.Login(admin, "Admin1", "Password1234");

            //Create 3 user
            var user1 = admin.CreateUser(GenerateId.GetID(), "Nicklas", "Eriksson", "MyUsername1", "Password123", "Pirate", 10);
            var user2 = admin.CreateUser(GenerateId.GetID(), "Mattias", "Vikström", "MyUsername2", "Password321", "Pirate", 10);
            var user3 = admin.CreateUser(GenerateId.GetID(), "Olle", "Svensson", "MyUsername3", "Password1337", "Pirate", 10);

            //Delete 1 user
            admin.DeleteAccount("Admin1", "Password1234", user2);

            //Change password of 1 user
            admin.ChangePassword(user1, "MyUsername1", "Password123", "NewPassword");

            //Get users
            var users = admin.GetUsers(admin);

            //Get salary of admin
            var salary = admin.GetSalary(admin);

            //Get role
            var role = admin.GetRole(admin);

            //Logout
            admin.Logout(admin);
        }

        [TestMethod()]
        public void UserTest()
        {
            Database.Start();
            var admin = new Admin();
            var newUser = admin.CreateUser(GenerateId.GetID(), "John", "Doe", "Johnny", "Password123", "Pirate", 10);

            //login
            newUser.Login(newUser, "Johnny", "Password123");
           
            //Get salary of admin
            var salary = newUser.GetSalary(newUser);

            //Get role
            var role = newUser.GetRole(newUser);

            var newPassword = newUser.ChangePassword(newUser, "Johnny", "Password123", "NewPassword123");

            //Logout
            newUser.Logout(newUser);
        }
    }

}

