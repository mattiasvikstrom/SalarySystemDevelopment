using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalarySystem_API.Tests
{
    [TestClass()]
    public class DatabaseTests
    {
        [TestMethod()]
        public void StartTest()
        {
            var doc = Database.Start();
            Assert.ReferenceEquals("", doc);
        }

        [TestMethod()]
        public void ClearDocTest()
        {
            var admin = new Admin();
            var success = Database.ClearDoc(admin);
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void ReWriteDocTest()
        {
            var success = Database.ReWriteDoc();
            Assert.IsTrue(success);
        }

        [TestMethod()]
        public void SaveUserTest()
        {
            var admin = new Admin();
            var newUser = admin.CreateUser(GenerateId.GetID(), "Brick", "Rick", "Username", "Password");
            var results = Database.SaveUser(newUser);
            Assert.IsTrue(results);
        }

        [TestMethod()]
        public void DeleteUserTest()
        {
            var admin = new Admin();

            var newUser = admin.CreateUser(GenerateId.GetID(), "Brick", "Rick", "Username", "Password");
            var results = admin.DeleteAccount(admin.Username, admin.Password, newUser);
            Assert.IsTrue(results);
        }

        [TestMethod()]
        public void GetUsersTest()
        {
            var admin = new Admin();
            var results = admin.GetUsers();//se över test.
            Assert.IsNotNull(results);
        }
    }
}