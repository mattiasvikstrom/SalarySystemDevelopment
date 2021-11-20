using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalarySystem_API.Tests
{
    [TestClass()]
    public class AdminTests
    {
        [TestMethod()]
        public void EditUserTest()
        {
            var admin = new Admin();
            admin.Login(admin, "Admin1", "admin1234");

            var success = admin.EditUser(admin, "Nicklas", "Eriksson", admin.Username, admin.Password);
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void GetRoleTest()
        {
            var admin = new Admin();
            admin.Login(admin, admin.Username, admin.Password);
            Database.ClearDoc(admin);

            var role = admin.GetRole(admin);
            Assert.AreEqual("Administrator", role);
        }

        [TestMethod()]
        public void GetSalaryTest()
        {
            var admin = new Admin();
            admin.Login(admin, admin.Username, admin.Password);
            Database.ClearDoc(admin);

            var salary = admin.GetSalary(admin);
            Assert.AreEqual(30000, salary);
        }

        [TestMethod()]
        public void LoginSuccessTest()
        {
            var admin = new Admin();
            admin.Login(admin, admin.Username, admin.Password);
            Database.ClearDoc(admin);

            var success = admin.Login(admin, "Admin1", "admin1234");
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void LoginFailTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var success = admin.Login(admin, admin.Username, "Password123444444");
            Assert.IsFalse(success);
        }

        [TestMethod()]
        public void LogoutTest()
        {
            var admin = new Admin();
            admin.Login(admin, admin.Username, admin.Password);
            Database.ClearDoc(admin);            

            var success = admin.Logout(admin);
            Assert.IsTrue(success);
        }


        [TestMethod()]
        public void ChangePasswordOnAdminTest()
        {
            var admin = new Admin();
            admin.Login(admin, admin.Username, admin.Password);
            Database.Start();
            var newPassword = admin.ChangePassword(admin, "Admin1", "admin1234", "NewPassword123");
            Assert.AreEqual("Admin may not change its own password.", newPassword);
        }

        [TestMethod()]
        public void ChangePasswordOnUserTest()
        {
            var admin = new Admin();
            admin.Login(admin, admin.Username, admin.Password);
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "Username", "Password1", "Pirate", 10);
            var newPassword = admin.ChangePassword(newUser, "Username", "Password1", "NewPassword123");
            Assert.AreEqual("newpassword123", newPassword);
        }

        [TestMethod()]
        public void CreateUserTest()
        {
            var id = GenerateId.GetID();

            var testUser = new User()
            {
                Id = id,
                FirstName = "John",
                Surname = "Doe",
                Username = "Username",
                Password = "Password123"
            };

            var newUser = new Admin().CreateUser(id, "John", "Doe", "Username", "Password123", "Pirate", 10);

            Assert.AreEqual(newUser.Id, testUser.Id);
            Assert.AreEqual(newUser.FirstName, testUser.FirstName);
            Assert.AreEqual(newUser.Surname, testUser.Surname);
            Assert.AreEqual(newUser.Username, testUser.Username);
            Assert.AreEqual(newUser.Password, testUser.Password);
        }

        [TestMethod()]
        public void DeleteAccountTest()
        {
            var admin = new Admin();
            admin.Login(admin, admin.Username, admin.Password);
            var user = admin.CreateUser(GenerateId.GetID(), "John", "Doe", "Johnny", "Password123", "Pirate", 10);
            var success = admin.DeleteAccount(admin.Username, admin.Password, user);

            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            var testUser = new User()
            {
                Id = GenerateId.GetID(),
                FirstName = "Test",
                Surname = "Doe",
                Username = "Username",
                Password = "Password123"
            };

            var admin = new Admin();
            admin.Login(admin, admin.Username, admin.Password);
            admin.CreateUser(GenerateId.GetID(), "John", "Doe", "Johnny", "Password123", "Pirate", 10);
            admin.CreateUser(GenerateId.GetID(), "Steve", "Doe", "Johnny", "Password123123", "Pirate", 10);
            var refUser = admin.GetUsers(admin);

            Assert.ReferenceEquals(testUser, refUser);
        }
    }
}