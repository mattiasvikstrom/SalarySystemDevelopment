using System.Collections.Generic;

namespace SalarySystem_API
{
    interface IAdmin : IUser
    {
        public User CreateUser(string id, string firstName, string surname, string username, string password);
        public IEnumerable<IUser> GetUsers();
    }
}
