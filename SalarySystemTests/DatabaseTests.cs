using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveUserTest()
        {
            Assert.Fail();
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
            Assert.Fail();
        }
    }
}