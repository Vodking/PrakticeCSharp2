using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrakticeCSharp2
{
    public abstract class Media
    {
        public string Title { get; set; }
        public string Author {  get; set; }
        public int YearPublished {  get; set; }

        public bool IsAvailable { get; set; }

        protected Media(string title, string author, int yearPublished)
        {
            Title = title;
            Author = author;
            YearPublished = yearPublished;
            IsAvailable = true;
        }

        public virtual string GetInfo()
        {
            return $"Название: {Title}, Автор: {Author}, Год: {YearPublished}, Доступно: {(IsAvailable ? "Да" : "Нет")}";
        }
    }
}
