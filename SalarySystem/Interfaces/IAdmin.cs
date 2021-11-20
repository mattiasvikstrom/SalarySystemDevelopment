using System.Collections.Generic;

namespace SalarySystem_API
{
    interface IAdmin : IUser
    {
        public User CreateUser(string id, string firstName, string surname, string username, string password, string role, int salary);
        public IEnumerable<IUser> GetUsers(IUser admin);
    }
}
