using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrakticeCSharp2
{
    public interface IMediaManager<T>
    {
        public void Add(T item);

        public bool Remove(string title);

        public T FindByTitle(string title);

        public IEnumerable<T> FilterByYear(int year);

        public IEnumerable<T> GetAllAvailable();
    }
}
