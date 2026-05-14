using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrakticeCSharp2
{
    public class MusicAlbum : Media
    {
        public string Performer {  get; set; }
        public int Tracks { get; set; }

        public MusicAlbum(string title, string author, int yearPublished, string performer, int trackCount)
           : base(title, author, yearPublished)
        {
            Performer = performer;
            Tracks = trackCount;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $", Исполнитель: {Performer}, Треков: {Tracks}";
        }
    }
}
