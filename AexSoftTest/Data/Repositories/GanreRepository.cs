using Data.ConnectDb;
using Data.Entities;
using SQLite;

namespace Data.Repositories
{
    public class GanreRepository
    {
        private readonly SQLiteConnection database;

        public GanreRepository()
        {
            database = new SQLiteConnection(ConnectSettings.PathDatabaseCollection);
            database.CreateTable<Ganre>();
        }

        public int AddGanre(Ganre item)
        {
            return database.Insert(item);
        }

        public int UpdateGanre(Ganre item)
        {
            return database.Update(item);
        }

    }
}
