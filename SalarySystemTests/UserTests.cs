using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalarySystem_API.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void EditUserTest()
        {
            var admin = new Admin();
            admin.Login(admin, admin.Username, admin.Password);
            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Eriksson", "MyUsername", "MyPassword", "Pirate", 10);

            newUser.Login(newUser, newUser.Username, newUser.Password);
            var success = newUser.EditUser(newUser, "CoolFirstName", "CoolSurname", "CoolUsername", "CoolPassword");
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void GetRoleTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);
            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Eriksson", "MyUsername", "MyPassword", "Pirate", 10);
            newUser.Login(newUser, "MyUsername", "MyPassword");
            var role = newUser.GetRole(newUser);
            Assert.AreEqual("Pirate", role);
        }

        [TestMethod()]
        public void GetSalaryTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);
            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Eriksson", "MyUsername", "MyPassword", "Pirate", 10);

            newUser.Login(newUser, "MyUsername", "MyPassword");
            var salary = newUser.GetSalary(newUser);
            Assert.AreEqual(10, salary);
        }

        [TestMethod()]
        public void LoginSuccessTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "MyUsername", "MyPassword", "Pirate", 10);
            var success = newUser.Login(newUser, "MyUsername", "MyPassword");
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void LoginFailTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "MyUsername", "MyPassword", "Pirate", 10);
            var success = newUser.Login(newUser, newUser.Username, "ASDFASDASD");
            Assert.IsFalse(success);
        }

        [TestMethod()]
        public void LogoutTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "MyUsername", "MyPassword", "Pirate", 10);
            newUser.Login(newUser, newUser.Username, newUser.Password);
            var success = newUser.Logout(newUser);
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void ChangePasswordTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "Username", "Password", "Pirate", 10);
            newUser.Login(newUser, newUser.Username, newUser.Password);
            var newPassword = newUser.ChangePassword(newUser, "Username", "Password", "NewPassword123");
            Assert.AreEqual("newpassword123", newPassword);
        }

        [TestMethod()]
        public void DeleteAccountTest()
        {
            var admin = new Admin();
            var newUser = admin.CreateUser(GenerateId.GetID(), "John", "Doe", "Johnny", "Password123", "Pirate", 10);
            Assert.AreEqual(newUser.Username, "Johnny");
            newUser.Login(newUser, newUser.Username, newUser.Password);
            var success = newUser.DeleteAccount(newUser.Username, newUser.Password, newUser);
            Assert.IsTrue(success);
        }
    }
}