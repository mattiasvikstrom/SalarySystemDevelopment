﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SalarySystem_API.Tests
{
    [TestClass()]
    public class AdminTests
    {
        [TestMethod()]
        public void ChangePasswordOnAdminTest()
        {
            Database.Start();
            var admin = new Admin();
            var newPassword = admin.ChangePassword(admin, "Admin1", "Password1234", "NewPassword123");
            Assert.AreEqual("Admin may not change its own password.", newPassword);
        }

        [TestMethod()]
        public void ChangePasswordOnUserTest()
        {
            var admin = new Admin();
            Database.ClearDoc(admin);

            var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "Username", "Password");
            var newPassword = admin.ChangePassword(newUser, "Username", "Password", "NewPassword123");
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

            var newUser = new Admin().CreateUser(id, "John", "Doe", "Username", "Password123");

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
            var user = admin.CreateUser(GenerateId.GetID(), "John", "Doe", "Johnny", "Password123");
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
            admin.CreateUser(GenerateId.GetID(), "John", "Doe", "Johnny", "Password123");
            admin.CreateUser(GenerateId.GetID(), "Steve", "Doe", "Johnny", "Password123123");
            var refUser = admin.GetUsers();

            Assert.ReferenceEquals(testUser, refUser);
        }
    }
}