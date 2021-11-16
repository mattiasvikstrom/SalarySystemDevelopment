using System;

namespace SalarySystem_API
{
    public class Account : IAccount
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }

        public string GetRole()
        {
            throw new NotImplementedException();
        }

        public int GetSalary()
        {
            throw new NotImplementedException();
        }
    }
}