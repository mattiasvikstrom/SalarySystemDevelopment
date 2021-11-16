using System;
using System.Collections.Generic;
using System.IO;

namespace SalarySystem_API
{
    public static class Database
    {
        private static List<string> doc = new List<string>();
        public static List<IUser> Users = new List<IUser>();
        private static string folder = "DataBase";
        private static string fileName = "Users.txt";
        private static string folderAndFile = folder + "\\" + fileName;
        private static string insertUser = "No user found";

        public static List<string> Start()
        {
            var admin = new Admin();
            Database.SaveUser(admin);

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

        public static void ReWriteDoc()
        {
            string temp = "";
            foreach (var row in doc)
            {
                temp += row + "\n";
            }

            File.WriteAllText(folderAndFile, temp);
        }

        public static bool SaveUser(IUser user)
        {
            try
            {
                Users.Add(user);

                insertUser = $"" +
                    $"ID = {user.Id}," +
                    $"\nFirst Name = {user.FirstName}," +
                    $"\nSurname = {user.Surname}," +
                    $"\nUsername = {user.Username}," +
                    $"\nPassword = {user.Password}," +
                    $"\nIs Admin = {user.IsAdmin}," +
                    $"\n*\n"; // * as break point

                CreateFolder(folder);

                File.AppendAllText(folderAndFile, insertUser);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static void CreateFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static bool DeleteUser(string id)
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
                foreach (var user in Users)
                {
                    if (user.Id == tempId)
                    {
                        Users.Remove(user);
                        break;
                    }
                }

                ReWriteDoc();
                return true;
            }

            return false;
        }

        public static List<IUser> GetUsers()
        {
            return Users;
        }

        public static bool ClearDoc(IUser user)
        {
            if (user.IsAdmin)
            {
                File.WriteAllText(folderAndFile, "");
                return true;
            }

            return false;
        }
    }
}
