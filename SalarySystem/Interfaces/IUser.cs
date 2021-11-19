namespace SalarySystem_API
{
    public interface IUser
    {
        string Id { get; set; }
        public bool IsAdmin { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        bool IsLoggedIn { get; set; }
        int Salary { get; set; }
        string Role { get; set; }

        public bool DeleteAccount(string adminUsername, string adminPassword, IUser user);
        public string ChangePassword(IUser user, string username, string oldPassword, string newPassword);
        public string GetRole(IUser user);
        public int GetSalary(IUser user);
        public bool Login(IUser user, string username, string password);
        public bool Logout(IUser user);
        public bool EditUser(IUser user, string newFirstName, string newSurname, string newUsername, string newPassword);
    }
}
