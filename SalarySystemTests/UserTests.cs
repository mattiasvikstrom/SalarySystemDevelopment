using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalarySystem_API.Tests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void ChangePasswordTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "Username", "Password");
            var newPassword = newUser.ChangePassword(newUser, "Username", "Password", "NewPassword123");
            Assert.AreEqual("newpassword123", newPassword);
        }

        [TestMethod()]
        public void DeleteAccountTest()
        {
            var admin = new Admin();
            var user = admin.CreateUser(GenerateId.GetID(), "John", "Doe", "Johnny", "Password123");
            Assert.AreEqual(user.Username, "Johnny");
            var success = user.DeleteAccount(user.Username, user.Password, user);
            Assert.IsTrue(success);
        }
    }
}