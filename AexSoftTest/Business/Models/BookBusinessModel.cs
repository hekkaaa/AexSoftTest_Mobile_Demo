using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class BookBusinessModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public string Genre { get; set; }
        public int AutorId { get; set; }
        public string Autor { get; set; }
        public int CoverViewId { get; set; }
        public string CoverView { get; set; }
        public int Storageid { get; set; }
        public string Row { get; set; }
        public string Rack { get; set; }
        public string Shelf { get; set; }
    }
}
