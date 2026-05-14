using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrakticeCSharp2
{
    public class Movie : Media
    {
        public int Time { get; set; }
        public string Director { get; set; }

        public Movie(string title, string author, int yearPublished, int durationMinutes, string director)
            : base(title, author, yearPublished)
        {
            Time = durationMinutes;
            Director = director;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Длительность: {Time} мин, Режиссер: {Director}";
        }
    }
}
