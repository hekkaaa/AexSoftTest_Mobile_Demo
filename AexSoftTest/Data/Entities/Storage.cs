using SQLite;

namespace Data.Entities
{
    [Table("Storage")]
    public class Storage
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Row { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
    }
}
