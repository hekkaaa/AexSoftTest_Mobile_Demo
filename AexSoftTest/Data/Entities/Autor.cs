using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Data.Entities
{
    [Table("Autor")]
    public class Autor
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        [ManyToMany(typeof(BookAutor))]
        public List<Book> BookId { get; set; }
    }
}
