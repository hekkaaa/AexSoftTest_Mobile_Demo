using System;
using System.IO;

namespace Data.ConnectDb
{
    public static class ConnectSettings
    {
        public const string DATABASE_COLLECTION_NAME = "book.db";
        public const string DATABASE_USER = "user.db";
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

    }
}
