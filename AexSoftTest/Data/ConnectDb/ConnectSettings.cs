using System;
using System.IO;

namespace Data.ConnectDb
{
    public static class ConnectSettings
    {
        private const string DEFAULT_NAME_USER_DB = "book.db";
        private static string DATABASE_COLLECTION_NAME = DEFAULT_NAME_USER_DB;
        private const string DATABASE_USER = "user.db";
        public static string PathDatabaseCollection
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + "/" + DATABASE_COLLECTION_NAME;
            }
        }

        public static string PathDatabaseUser
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + "/" + DATABASE_USER;
            }
        }

        public static void RenameDatabaseUser(string userName)
        {   
            DATABASE_COLLECTION_NAME = userName + "_" + DEFAULT_NAME_USER_DB;
        }

    }
}
