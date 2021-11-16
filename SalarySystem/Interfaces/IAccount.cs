namespace SalarySystem_API
{
    interface IAccount
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
        public int Salary { get; set; }

        public int GetSalary();
        public string GetRole();
    }
}
