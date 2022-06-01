using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class BookAutor
    {
        [ForeignKey(typeof(Book))]
        public int BookId { get; set; }

        [ForeignKey(typeof(Autor))]
        public int AutorId { get; set; }
    }
}
