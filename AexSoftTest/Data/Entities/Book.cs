using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace Data.Entities
{
    [Table("Book")]
    public class Book
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [OneToOne()]
        public CoverView CoverView { get; set; }

        [ForeignKey(typeof(CoverView))]
        public int CoverViewId { get; set; }

        [ManyToMany(typeof(BookGanre))]
        public List<Ganre> Ganre { get; set; }

        [ManyToMany(typeof(BookAutor))]
        public List<Autor> Autors { get; set; }

        [ForeignKey(typeof(Storage))]
        public int StorageId { get; set; }

        [OneToOne]
        public Storage StorageAddress { get; set; }
    }
}
