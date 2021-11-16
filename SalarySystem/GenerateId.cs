using System;

namespace SalarySystem_API
{
    public static class GenerateId
    {
        public static string GetID()
        {
            var rnd = new Random();
            var nextRandom = rnd.Next(1, int.MaxValue - 1);
            return $"#{nextRandom}.{DateTime.Now}";
        }
    }
}