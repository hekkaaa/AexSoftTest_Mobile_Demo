using SQLite;

namespace Data.Entities
{
    [Table("CoverView")]
    public class CoverView
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Path { get; set; }
    }
}
