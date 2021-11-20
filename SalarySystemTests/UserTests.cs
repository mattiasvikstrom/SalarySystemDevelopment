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
            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Eriksson", "MyUsername", "MyPassword1", "Pirate", 10);

            newUser.Login(newUser, newUser.Username, newUser.Password);
            var success = newUser.EditUser(newUser, "CoolFirstName", "CoolSurname", "CoolUsername", "CoolPassword1");
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void GetRoleTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);
            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Eriksson", "MyUsername", "MyPassword1", "Pirate", 10);
            newUser.Login(newUser, "MyUsername", "MyPassword1");
            var role = newUser.GetRole(newUser);
            Assert.AreEqual("Pirate", role);
        }

        [TestMethod()]
        public void GetSalaryTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);
            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Eriksson", "MyUsername", "MyPassword1", "Pirate", 10);

            newUser.Login(newUser, "MyUsername", "MyPassword1");
            var salary = newUser.GetSalary(newUser);
            Assert.AreEqual(10, salary);
        }

        [TestMethod()]
        public void LoginSuccessTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "MyUsername", "MyPassword1", "Pirate", 10);
            var success = newUser.Login(newUser, "MyUsername", "MyPassword1");
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void LoginFailTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "MyUsername", "MyPassword1", "Pirate", 10);
            var success = newUser.Login(newUser, newUser.Username, "ASDFASDASD");
            Assert.IsFalse(success);
        }

        [TestMethod()]
        public void LogoutTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "MyUsername", "MyPassword1", "Pirate", 10);
            newUser.Login(newUser, newUser.Username, newUser.Password);
            var success = newUser.Logout(newUser);
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void ChangePasswordSuccessTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "Username", "Password1", "Pirate", 10);
            newUser.Login(newUser, newUser.Username, newUser.Password);
            var newPassword = newUser.ChangePassword(newUser, "Username", "Password1", "NewPassword123");
            Assert.AreEqual("newpassword123", newPassword);
        }

        [TestMethod()]
        public void ChangePasswordFailNoDigitTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "Username", "Password1", "Pirate", 10);
            newUser.Login(newUser, newUser.Username, newUser.Password);
            var res = newUser.ChangePassword(newUser, "Username", "Password1", "NewPasswordNoDigit");
            Assert.AreEqual("Password needs to contain a digit.", res);
        }

        [TestMethod()]
        public void ChangePasswordFailToShortPasswordTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "Username", "Password1", "Pirate", 10);
            newUser.Login(newUser, newUser.Username, newUser.Password);
            var res = newUser.ChangePassword(newUser, "Username", "Password1", "NP1");
            Assert.AreEqual("Password needs to be for or more letters and digits.", res);
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