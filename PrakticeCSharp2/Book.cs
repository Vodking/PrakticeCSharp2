using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrakticeCSharp2
{
    public class Book : Media
    {
        public int Pages {  get; set; }
        public string Genre { get; set; }

        public Book(string title, string author, int yearPublished, int pageCount, string genre)
            : base(title, author, yearPublished)
        {
            Pages = pageCount;
            Genre = genre;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Страниц: {Pages}, Жанр: {Genre}";
        }
    }
}
