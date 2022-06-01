using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Data.Entities
{
    [Table("Book")]
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(typeof(Ganre))]
        public int GanreId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeDelete)]
        public Ganre Ganre { get; set; }

        [ForeignKey(typeof(Autor))]
        public int AutorId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeDelete)]
        public Autor Autors { get; set; }

        [ForeignKey(typeof(CoverView))]
        public int CoverViewId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeDelete)]
        public CoverView CoverView { get; set; }

        [ForeignKey(typeof(Storage))]
        public int StorageId { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.CascadeDelete)]
        public Storage Storage { get; set; }
    }
}
