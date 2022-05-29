using SQLite;

namespace Data.Entities
{
    [Table("Book")]
    public class Book
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Autor { get; set; }
        public string CoverView { get; set; }
        public string Row { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
    }
}
