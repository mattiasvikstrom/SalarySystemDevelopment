using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalarySystem_API;

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
        //Create 3 user
        //Delete 1 user
        //Change password of 1 user
        //Get users
        //Get salary of admin
        //Get role
        //Logout
    }

    [TestMethod()]
    public void UserTest()
    {
        //var admin = new Admin();
        //Database.ClearDoc(admin);

        //var newUser = admin.CreateUser(GenerateId.GetID(), "Nick", "Erik", "Username", "Password");
        //var newPassword = admin.ChangePassword(newUser, "Username", "Password", "NewPassword123");
    }
}
