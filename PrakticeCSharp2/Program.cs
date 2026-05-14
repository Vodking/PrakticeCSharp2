namespace PrakticeCSharp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. РАБОТА С КНИГАМИ");
            Console.WriteLine("-------------------");
            Library<Book> bookLibrary = new Library<Book>();

            bookLibrary.Add(new Book("Война и мир", "Лев Толстой", 1869, 1225, "Роман"));
            bookLibrary.Add(new Book("Преступление и наказание", "Федор Достоевский", 1866, 672, "Роман"));
            bookLibrary.Add(new Book("Мастер и Маргарита", "Михаил Булгаков", 1967, 480, "Фантастика"));

            bookLibrary.PrintAll();

            Console.WriteLine("\nПоиск книги 'Мастер и Маргарита'");
            var foundBook = bookLibrary.FindByTitle("Мастер и Маргарита");
            Console.WriteLine(foundBook.GetInfo());

            Console.WriteLine("\nВыдача книги");
            bookLibrary.CheckOut("Война и мир");
            bookLibrary.PrintAll();

            Console.WriteLine("\nКниги, выпущенные после 1900 года");
            var booksAfter1900 = bookLibrary.GetBooksAfterYear(1900);
            foreach (var book in booksAfter1900)
            {
                Console.WriteLine(book.GetInfo());
            }

            Console.WriteLine("\nВозврат книги");
            bookLibrary.Return("Война и мир");
            bookLibrary.PrintAll();

            Console.WriteLine("\n\n2. РАБОТА С ФИЛЬМАМИ");
            Console.WriteLine();
            Library<Movie> movieLibrary = new Library<Movie>();

            movieLibrary.Add(new Movie("Побег из Шоушенка", "Стивен Кинг", 1994, 142, "Фрэнк Дарабонт"));
            movieLibrary.Add(new Movie("Крестный отец", "Марио Пьюзо", 1972, 175, "Фрэнсис Форд Коппола"));
            movieLibrary.Add(new Movie("Темный рыцарь", "Кристофер Нолан", 2008, 152, "Кристофер Нолан"));

            movieLibrary.PrintAll();

            Console.WriteLine("\n--- Фильмы, отсортированные по длительности ---");
            var sortedMovies = movieLibrary.GetMoviesSortedByDuration();
            foreach (var movie in sortedMovies)
            {
                Console.WriteLine($"{movie.Title} - {movie.Time} мин");
            }

            Console.WriteLine("\n\n3. РАБОТА С МУЗЫКАЛЬНЫМИ АЛЬБОМАМИ");
            Console.WriteLine();
            Library<MusicAlbum> musicLibrary = new Library<MusicAlbum>();

            musicLibrary.Add(new MusicAlbum("Abbey Road", "The Beatles", 1969, "The Beatles", 17));
            musicLibrary.Add(new MusicAlbum("Thriller", "Michael Jackson", 1982, "Michael Jackson", 9));
            musicLibrary.Add(new MusicAlbum("Dark Side of the Moon", "Pink Floyd", 1973, "Pink Floyd", 10));

            musicLibrary.PrintAll();

            Console.WriteLine("\nАльбомы 1973 года");
            var albums1973 = musicLibrary.FilterByYear(1973);
            foreach (var album in albums1973)
            {
                Console.WriteLine(album.GetInfo());
            }

            Console.WriteLine("\nВсе доступные альбомы");
            var availableAlbums = musicLibrary.GetAllAvailable();
            foreach (var album in availableAlbums)
            {
                Console.WriteLine(album.GetInfo());
            }

            Console.WriteLine("\nВыдача альбома Thriller");
            musicLibrary.CheckOut("Thriller");

            Console.WriteLine("\nНедоступные элементы");
            var unavailable = musicLibrary.GetUnavailableItems();
            foreach (var item in unavailable)
            {
                Console.WriteLine(item.GetInfo());
            }

            Console.WriteLine("\n\nРАБОТА ЗАВЕРШЕНА");
        }
    }
}
