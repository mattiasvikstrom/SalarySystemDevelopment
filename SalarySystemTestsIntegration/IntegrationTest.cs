using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalarySystem_API.TestsIntegration
{
    [TestClass()]
    public class IntegrationTest
    {
        [TestMethod()]
        public void AdminTest()
        {
            Database.Start();
            var admin = new Admin();

            //login
            Assert.IsTrue(admin.Login(admin, "Admin1", "admin1234"));

            //Create 2 user
            var user1 = admin.CreateUser(GenerateId.GetID(), "Nicklas", "Eriksson", "MyUsername1", "Password123", "Pirate", 10);
            var user2 = admin.CreateUser(GenerateId.GetID(), "Mattias", "Vikström", "MyUsername2", "Password321", "Pirate", 10);
            
            //Delete 1 user
            Assert.IsTrue(admin.DeleteAccount("Admin1", "admin1234", user2));

            //Change password of 1 user
            Assert.AreEqual("newpassword1", admin.ChangePassword(user1, "MyUsername1", "Password123", "newpassword1"));

            //Get users
            Assert.ReferenceEquals(user1, admin.GetUsers(admin));

            //Get salary of admin
            Assert.AreEqual(30000, admin.GetSalary(admin));

            //Get role
            Assert.AreEqual("Administrator", admin.GetRole(admin));

            //Logout
            Assert.IsTrue(admin.Logout(admin));
        }

        [TestMethod()]
        public void UserTest()
        {
            Database.Start();
            var admin = new Admin();
            var newUser = admin.CreateUser(GenerateId.GetID(), "John", "Doe", "Johnny", "Password123", "Pirate", 10);

            //login
            Assert.IsTrue(newUser.Login(newUser, "Johnny", "Password123"));

            //Get salary of user
            Assert.AreEqual(10, newUser.GetSalary(newUser));

            //Get role
            Assert.AreEqual("Pirate", newUser.GetRole(newUser));

            //Change password
            Assert.AreEqual("newpassword123", newUser.ChangePassword(newUser, "Johnny", "Password123", "newpassword123"));

            //Logout
            Assert.IsTrue(newUser.Logout(newUser));
        }
    }

}

