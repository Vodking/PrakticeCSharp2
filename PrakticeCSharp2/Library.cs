using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrakticeCSharp2
{
    public class Library<T> : IMediaManager<T> where T : Media
    {
        private List<T> _mediaList;
        private Dictionary<string, T> _mediaDict;

        public Library()
        {
            _mediaList = new List<T>();
            _mediaDict = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
        }

        public void Add(T item)
        {
            if (item == null)
                Console.WriteLine("Медиа не может быть null");

            if (_mediaDict.ContainsKey(item.Title))
                Console.WriteLine("Медиа с таким названием уже существует");

            _mediaList.Add(item);
            _mediaDict.Add(item.Title, item);
            Console.WriteLine($"Добавлено: {item.GetInfo()}");
        }

        public bool Remove(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                Console.WriteLine("Название не может быть пустым");

            if (!_mediaDict.ContainsKey(title))
                Console.WriteLine("Медиа с таким названием не найдено");

            T item = _mediaDict[title];
            _mediaList.Remove(item);
            _mediaDict.Remove(title);
            Console.WriteLine($"Удалено: {item.GetInfo()}");
            return true;
        }
        public T FindByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                Console.WriteLine("Название не может быть пустым");

            if (!_mediaDict.TryGetValue(title, out T item))
                Console.WriteLine("Медиа с таким названием не найдено");

            return item;
        }

        public IEnumerable<T> FilterByYear(int year)
        {
            return _mediaList.Where(m => m.YearPublished == year);
        }

        public IEnumerable<T> GetAllAvailable()
        {
            return _mediaList.Where(m => m.IsAvailable);
        }

        public bool CheckOut(string title)
        {
            T item = FindByTitle(title);
            if (!item.IsAvailable)
                Console.WriteLine("Медиа уже выдано");

            item.IsAvailable = false;
            Console.WriteLine($"Выдано: {title}");
            return true;
        }

        public bool Return(string title)
        {
            T item = FindByTitle(title);
            if (item.IsAvailable)
                Console.WriteLine("Медиа уже доступно");

            item.IsAvailable = true;
            Console.WriteLine($"Возвращено: {title}");
            return true;
        }

        public void PrintAll()
        {
            if (_mediaList.Count == 0)
            {
                Console.WriteLine("Библиотека пуста");
                return;
            }

            Console.WriteLine($"\n=== Все медиа ({typeof(T).Name}) ===");
            foreach (var item in _mediaList)
            {
                Console.WriteLine(item.GetInfo());
            }
            Console.WriteLine();
        }

        public IEnumerable<Book> GetBooksAfterYear(int year)
        {
            return _mediaList.OfType<Book>().Where(b => b.YearPublished > year);
        }

        public IEnumerable<Movie> GetMoviesSortedByDuration()
        {
            return _mediaList.OfType<Movie>().OrderBy(m => m.Time);
        }


        public IEnumerable<T> GetUnavailableItems()
        {
            return _mediaList.Where(m => !m.IsAvailable);
        }
    }
}
