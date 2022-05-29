using System;
using System.IO;

namespace Data.ConnectDb
{
    public static class ConnectSettings
    {
        public const string DATABASE_NAME = "book.db";
        public static string PathDatabase
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)) + "/" + DATABASE_NAME;
            }
        }
    }
}
