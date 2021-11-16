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

        public bool DeleteAccount(string adminUsername, string adminPassword, IUser user);
        public string ChangePassword(IUser user, string username, string oldPassword, string newPassword);
    }
}
