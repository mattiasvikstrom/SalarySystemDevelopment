using SalarySystem_API;
using System.Collections.Generic;
using System.IO;

namespace DatabaseSalarySystem
{
    public class Db
    {
        private List<string> doc = new List<string>();
        private static List<User> users = new List<User>();
        private static string folder = "DataBase";
        private static string fileName = "Users.txt";
        private static string folderAndFile = folder + "\\" + fileName;
        private static string insertUser = "No user found";

        private List<string> GeatStream()
        {
            using (var sr = new StreamReader(folderAndFile))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    doc.Add(line);
                }
            }

            return doc;
        }

        public void ReWriteDoc()
        {
            string temp = "";
            foreach (var row in doc)
            {
                temp += row + "\n";
            }

            File.WriteAllText(folderAndFile, temp);
        }

        public bool SaveUser(User user)
        {
            users.Add(user);

            insertUser = $"" +
                $"ID = {user.Id}," +
                $"\nFirst Name = {user.FirstName}," +
                $"\nSurname = {user.Surname}," +
                $"\nUsername = {user.Username}," +
                $"\nPassword = {user.Password}," +
                $"\nIs Admin = {user.IsAdmin}," +
                $"\n*\n"; // * as break point :)

            CreateFolder(folder);

            File.AppendAllText(folderAndFile, insertUser);

            return false; //TEMP
        }

        private void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private bool DeleteUser(string id)
        {
            int index = -1;
            string tempId = "";
            for (int i = 0; i < doc.Count; i++)
            {
                if (doc[i].Contains($"ID = {id}"))
                {
                    index = i;
                    var temp = doc[i];
                    tempId = temp.Substring(5, temp.Length - 6);
                    break;
                }
            }

            if (index != -1)
            {
                doc.RemoveRange(index, 7);
                foreach (var user in users)
                {
                    if (user.Id == tempId)
                    {
                        users.Remove(user);
                    }
                }
                ReWriteDoc();
                return true;
            }

            return false;
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}
