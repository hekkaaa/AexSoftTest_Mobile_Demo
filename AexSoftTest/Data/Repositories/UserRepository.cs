using Data.ConnectDb;
using Data.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    public class UserRepository
    {
        private readonly SQLiteConnection database;

        public UserRepository()
        {
            database = new SQLiteConnection(ConnectSettings.PathDatabaseUser);
            database.CreateTable<User>();
        }

        public User GetUserByName(string name)
        {
           var tmpRes = database.Table<User>().ToList();
           return tmpRes.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
        }

        public int AddUser(User newUser)
        {
            return database.Insert(newUser);
        }
    }
}
