using SQLiteNetExtensions.Attributes;

namespace Data.Entities
{
    public class BookGanre
    {
        [ForeignKey(typeof(Book))]
        public int BookId { get; set; }

        [ForeignKey(typeof(Ganre))]
        public int GanreId { get; set; }
    }
}
