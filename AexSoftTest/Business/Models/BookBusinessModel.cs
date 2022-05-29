using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
    public class BookBusinessModel
    {
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
