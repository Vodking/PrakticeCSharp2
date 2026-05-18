using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
                throw new ArgumentNullException(nameof(item), "Медиа не может быть null");

            if (_mediaDict.ContainsKey(item.Title))
                throw new InvalidOperationException($"Медиа с названием '{item.Title}' уже существует");

            _mediaList.Add(item);
            _mediaDict.Add(item.Title, item);
            Console.WriteLine($"Добавлено: {item.GetInfo()}");
        }

        public bool Remove(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название не может быть пустым", nameof(title));

            if (!_mediaDict.ContainsKey(title))
                throw new KeyNotFoundException($"Медиа с названием '{title}' не найдено");

            T item = _mediaDict[title];
            _mediaList.Remove(item);
            _mediaDict.Remove(title);
            Console.WriteLine($"Удалено: {item.GetInfo()}");
            return true;
        }
        public T FindByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название не может быть пустым", nameof(title));


            if (!_mediaDict.TryGetValue(title, out T item))
                throw new KeyNotFoundException($"Медиа с названием '{title}' не найдено");

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
                throw new InvalidOperationException($"Медиа '{title}' уже выдано");

            item.IsAvailable = false;
            Console.WriteLine($"Выдано: {title}");
            return true;
        }

        public bool Return(string title)
        {
            T item = FindByTitle(title);
            if (item.IsAvailable)
                throw new InvalidOperationException($"Медиа '{title}' и так доступно");

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

        public List<T> GetAllItems()
        {
            return _mediaList.ToList();
        }


        public void ExportToFile(string fileName)
        {
            var options = new FileStreamOptions
            {
                Mode = FileMode.OpenOrCreate,
                Access = FileAccess.Write, 
                Share = FileShare.Read,

            };

            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            using var stream = new FileStream("data.txt", options);
            using var writer = new StreamWriter(stream, Encoding.UTF8);

            string json = JsonConvert.SerializeObject(_mediaDict, settings);
            Console.WriteLine(json);

            File.WriteAllText($"{fileName}.json", json);
        }
    }
}
