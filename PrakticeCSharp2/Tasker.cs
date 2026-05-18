using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PrakticeCSharp2
{
    public static class Tasker
    {

        private static Library<Book> bookLibrary = new Library<Book>();
        private static Library<Movie> movieLibrary = new Library<Movie>();
        private static Library<MusicAlbum> musicLibrary = new Library<MusicAlbum>();

        public static void Task1()
        {
            InitializeTestData();

            bool exit = false;
            while (!exit)
            {
                ShowMainMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ManageBooks();
                        break;
                    case "2":
                        ManageMovies();
                        break;
                    case "3":
                        ManageMusic();
                        break;
                    case "4":
                        SearchAllMedia();
                        break;
                    case "5":
                        ShowStatistics();
                        break;
                    case "6":
                        ExportData();
                        break;
                    case "0":
                        exit = true;
                        break;
                }

                if (choice != "0")
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("МЕДИА-БИБЛИОТЕКА");
            Console.WriteLine("1.Управление книгами");
            Console.WriteLine("2. Управление фильмами");
            Console.WriteLine("3. Управление музыкальными альбомами");
            Console.WriteLine("4. Поиск по всем медиа");
            Console.WriteLine("5. Статистика");
            Console.WriteLine("6. Экспорт в файл");
            Console.WriteLine("0. Выход");
            Console.Write("\nВыберите действие: ");
        }

        public static void ManageBooks()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("УПРАВЛЕНИЕ КНИГАМИ");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Найти книгу");
                Console.WriteLine("4. Выдать книгу");
                Console.WriteLine("5. Вернуть книгу");
                Console.WriteLine("6. Показать все книги");
                Console.WriteLine("7. Фильтр книг после года");
                Console.WriteLine("8. Показать недоступные книги");
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddBook();
                        break;
                    case "2":
                        RemoveBook();
                        break;
                    case "3":
                        FindBook();
                        break;
                    case "4":
                        CheckOutBook();
                        break;
                    case "5":
                        ReturnBook();
                        break;
                    case "6":
                        bookLibrary.PrintAll();
                        break;
                    case "7":
                        FilterBooksByYear();
                        break;
                    case "8":
                        ShowUnavailableBooks();
                        break;
                    case "0":
                        back = true;
                        break;
                }

                if (choice != "0")
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        public static void AddBook()
        {
            Console.WriteLine("Добавление книги");
            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Автор: ");
            string author = Console.ReadLine();
            Console.Write("Год издания: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Количество страниц: ");
            int pages = int.Parse(Console.ReadLine());
            Console.Write("Жанр: ");
            string genre = Console.ReadLine();

            bookLibrary.Add(new Book(title, author, year, pages, genre));
        }

        public static void RemoveBook()
        {
            Console.WriteLine("Удаление книги");
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            bookLibrary.Remove(title);
        }

        public static void FindBook()
        {
            Console.WriteLine("Поиск книги");
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            var book = bookLibrary.FindByTitle(title);
            Console.WriteLine($"\nНайдено:\n{book.GetInfo()}");
        }

        public static void CheckOutBook()
        {
            Console.WriteLine("Выдача книги");
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            bookLibrary.CheckOut(title);
        }

        static void ReturnBook()
        {
            Console.WriteLine("Возврат книги");
            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();
            bookLibrary.Return(title);
        }

        public static void FilterBooksByYear()
        {
            Console.WriteLine("Книги после определенного года");
            Console.Write("Введите год: ");
            int year = int.Parse(Console.ReadLine());
            var books = bookLibrary.GetBooksAfterYear(year);

            if (!books.Any())
                Console.WriteLine($"Книг после {year} года не найдено");
            else
            {
                Console.WriteLine($"\nКниги, изданные после {year} года:");
                foreach (var book in books)
                    Console.WriteLine(book.GetInfo());

            }
        }

        public static void ShowUnavailableBooks()
        {
            var unavailable = bookLibrary.GetUnavailableItems();
            if (!unavailable.Any())
                Console.WriteLine("Нет недоступных книг");
            else
            {
                Console.WriteLine("Недоступные книги:");
                foreach (var book in unavailable)
                    Console.WriteLine(book.GetInfo());
            }
        }

        public static void ManageMovies()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("УПРАВЛЕНИЕ ФИЛЬМАМИ");
                Console.WriteLine("1. Добавить фильм");
                Console.WriteLine("2. Удалить фильм");
                Console.WriteLine("3. Найти фильм");
                Console.WriteLine("4. Выдать фильм");
                Console.WriteLine("5. Вернуть фильм");
                Console.WriteLine("6. Показать все фильмы");
                Console.WriteLine("7. Сортировать фильмы по длительности");
                Console.WriteLine("8. Показать недоступные фильмы");
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddMovie();
                        break;
                    case "2":
                        RemoveMovie();
                        break;
                    case "3":
                        FindMovie();
                        break;
                    case "4":
                        CheckOutMovie();
                        break;
                    case "5":
                        ReturnMovie();
                        break;
                    case "6":
                        movieLibrary.PrintAll();
                        break;
                    case "7":
                        ShowMoviesSortedByDuration();
                        break;
                    case "8":
                        ShowUnavailableMovies();
                        break;
                    case "0":
                        back = true;
                        break;
                }

                if (choice != "0")
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        public static void AddMovie()
        {
            Console.WriteLine("Добавление фильма");
            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Автор/Сценарист: ");
            string author = Console.ReadLine();
            Console.Write("Год выпуска: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Длительность (минуты): ");
            int duration = int.Parse(Console.ReadLine());
            Console.Write("Режиссер: ");
            string director = Console.ReadLine();

            movieLibrary.Add(new Movie(title, author, year, duration, director));
        }

        public static void RemoveMovie()
        {
            Console.WriteLine("Удаление фильма");
            Console.Write("Введите название фильма: ");
            string title = Console.ReadLine();
            movieLibrary.Remove(title);
        }

        public static void FindMovie()
        {
            Console.WriteLine("Поиск фильма");
            Console.Write("Введите название фильма: ");
            string title = Console.ReadLine();
            var movie = movieLibrary.FindByTitle(title);
            Console.WriteLine($"\nНайдено:\n{movie.GetInfo()}");
        }

        public static void CheckOutMovie()
        {
            Console.WriteLine("Выдача фильма");
            Console.Write("Введите название фильма: ");
            string title = Console.ReadLine();
            movieLibrary.CheckOut(title);
        }

        public static void ReturnMovie()
        {
            Console.WriteLine("Возврат фильма");
            Console.Write("Введите название фильма: ");
            string title = Console.ReadLine();
            movieLibrary.Return(title);
        }

        static void ShowMoviesSortedByDuration()
        {
            var sorted = movieLibrary.GetMoviesSortedByDuration();
            if (!sorted.Any())
                Console.WriteLine("Нет фильмов в библиотеке");
            else
            {
                Console.WriteLine("Фильмы, отсортированные по длительности:");
                foreach (var movie in sorted)
                    Console.WriteLine($"{movie.Title} - {movie.Time} мин - {movie.Director}");
            }
        }

        public static void ShowUnavailableMovies()
        {
            var unavailable = movieLibrary.GetUnavailableItems();
            if (!unavailable.Any())
                Console.WriteLine("Нет недоступных фильмов");
            else
            {
                Console.WriteLine("Недоступные фильмы:");
                foreach (var movie in unavailable)
                    Console.WriteLine(movie.GetInfo());
            }
        }

        public static void ManageMusic()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("УПРАВЛЕНИЕ МУЗЫКАЛЬНЫМИ АЛЬБОМАМИ");
                Console.WriteLine("1. Добавить альбом");
                Console.WriteLine("2. Удалить альбом");
                Console.WriteLine("3. Найти альбом");
                Console.WriteLine("4. Выдать альбом");
                Console.WriteLine("5. Вернуть альбом");
                Console.WriteLine("6. Показать все альбомы");
                Console.WriteLine("7. Фильтр альбомов по году");
                Console.WriteLine("8. Показать недоступные альбомы");
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите действие: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddMusicAlbum();
                        break;
                    case "2":
                        RemoveMusicAlbum();
                        break;
                    case "3":
                        FindMusicAlbum();
                        break;
                    case "4":
                        CheckOutMusicAlbum();
                        break;
                    case "5":
                        ReturnMusicAlbum();
                        break;
                    case "6":
                        musicLibrary.PrintAll();
                        break;
                    case "7":
                        FilterMusicByYear();
                        break;
                    case "8":
                        ShowUnavailableMusic();
                        break;
                    case "0":
                        back = true;
                        break;

                }

                if (choice != "0")
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                }
            }
        }

        public static void AddMusicAlbum()
        {
            Console.WriteLine("Добавление музыкального альбома");
            Console.Write("Название: ");
            string title = Console.ReadLine();
            Console.Write("Автор/Композитор: ");
            string author = Console.ReadLine();
            Console.Write("Год выпуска: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Исполнитель: ");
            string performer = Console.ReadLine();
            Console.Write("Количество треков: ");
            int tracks = int.Parse(Console.ReadLine());

            musicLibrary.Add(new MusicAlbum(title, author, year, performer, tracks));
        }

        public static void RemoveMusicAlbum()
        {
            Console.WriteLine("Удаление альбома");
            Console.Write("Введите название альбома: ");
            string title = Console.ReadLine();
            musicLibrary.Remove(title);
        }

        public static void FindMusicAlbum()
        {
            Console.WriteLine("Поиск альбома");
            Console.Write("Введите название альбома: ");
            string title = Console.ReadLine();
            var album = musicLibrary.FindByTitle(title);
            Console.WriteLine($"\nНайдено:\n{album.GetInfo()}");
        }

        public static void CheckOutMusicAlbum()
        {
            Console.WriteLine("Выдача альбома");
            Console.Write("Введите название альбома: ");
            string title = Console.ReadLine();
            musicLibrary.CheckOut(title);
        }

        public static void ReturnMusicAlbum()
        {
            Console.WriteLine("Возврат альбома");
            Console.Write("Введите название альбома: ");
            string title = Console.ReadLine();
            musicLibrary.Return(title);
        }

        public static void FilterMusicByYear()
        {
            Console.WriteLine("Альбомы по году выпуска");
            Console.Write("Введите год: ");
            int year = int.Parse(Console.ReadLine());
            var albums = musicLibrary.FilterByYear(year);

            if (!albums.Any())
                Console.WriteLine($"Альбомов {year} года не найдено");
            else
            {
                Console.WriteLine($"\nАльбомы {year} года:");
                foreach (var album in albums)
                    Console.WriteLine(album.GetInfo());
            }
        }

        public static void ShowUnavailableMusic()
        {
            var unavailable = musicLibrary.GetUnavailableItems();
            if (!unavailable.Any())
                Console.WriteLine("Нет недоступных альбомов");
            else
            {
                Console.WriteLine("Недоступные альбомы:");
                foreach (var album in unavailable)
                    Console.WriteLine(album.GetInfo());
            }
        }

        static void SearchAllMedia()
        {
            Console.Clear();
            Console.WriteLine("ПОИСК ПО ВСЕМ МЕДИА");
            Console.Write("Введите название для поиска: ");
            string title = Console.ReadLine();
            Console.WriteLine();

            bool found = false;

            var book = bookLibrary.FindByTitle(title);
            Console.WriteLine($"КНИГА: {book.GetInfo()}");
            found = true;

            var movie = movieLibrary.FindByTitle(title);
            Console.WriteLine($"ФИЛЬМ: {movie.GetInfo()}");
            found = true;

            var music = musicLibrary.FindByTitle(title);
            Console.WriteLine($"АЛЬБОМ: {music.GetInfo()}");
            found = true;

            if (!found)
                Console.WriteLine($"Медиа с названием '{title}' не найдено ни в одной категории");
        }

        public static void ShowStatistics()
        {
            Console.Clear();
            Console.WriteLine("СТАТИСТИКА БИБЛИОТЕКИ\n");

            var allBooks = bookLibrary.GetAllAvailable();
            var allMovies = movieLibrary.GetAllAvailable();
            var allMusic = musicLibrary.GetAllAvailable();

            Console.WriteLine($"КНИГИ:");
            Console.WriteLine($"Всего: {bookLibrary.GetAllAvailable().Count() + bookLibrary.GetUnavailableItems().Count()}");
            Console.WriteLine($"Доступно: {bookLibrary.GetAllAvailable().Count()}");
            Console.WriteLine($"Выдано: {bookLibrary.GetUnavailableItems().Count()}");

            Console.WriteLine($"\nФИЛЬМЫ:");
            Console.WriteLine($"Всего: {movieLibrary.GetAllAvailable().Count() + movieLibrary.GetUnavailableItems().Count()}");
            Console.WriteLine($"Доступно: {movieLibrary.GetAllAvailable().Count()}");
            Console.WriteLine($"Выдано: {movieLibrary.GetUnavailableItems().Count()}");

            Console.WriteLine($"\nАЛЬБОМЫ:");
            Console.WriteLine($"Всего: {musicLibrary.GetAllAvailable().Count() + musicLibrary.GetUnavailableItems().Count()}");
            Console.WriteLine($"Доступно: {musicLibrary.GetAllAvailable().Count()}");
            Console.WriteLine($"Выдано: {musicLibrary.GetUnavailableItems().Count()}");

            int total = (bookLibrary.GetAllAvailable().Count() + bookLibrary.GetUnavailableItems().Count() +
                        movieLibrary.GetAllAvailable().Count() + movieLibrary.GetUnavailableItems().Count() +
                        musicLibrary.GetAllAvailable().Count() + musicLibrary.GetUnavailableItems().Count());

            Console.WriteLine($"\nОБЩАЯ СТАТИСТИКА:");
            Console.WriteLine($"Всего медиа: {total}");
            Console.WriteLine($"Доступно: {bookLibrary.GetAllAvailable().Count() + movieLibrary.GetAllAvailable().Count() + musicLibrary.GetAllAvailable().Count()}");
            Console.WriteLine($"Выдано: {bookLibrary.GetUnavailableItems().Count() + movieLibrary.GetUnavailableItems().Count() + musicLibrary.GetUnavailableItems().Count()}");
        }



        static void InitializeTestData()
        {
            bookLibrary.Add(new Book("Война и мир", "Лев Толстой", 1869, 1225, "Роман"));
            bookLibrary.Add(new Book("Преступление и наказание", "Федор Достоевский", 1866, 672, "Роман"));
            bookLibrary.Add(new Book("Мастер и Маргарита", "Михаил Булгаков", 1967, 480, "Фантастика"));
            bookLibrary.Add(new Book("1984", "Джордж Оруэлл", 1949, 328, "Антиутопия"));

            movieLibrary.Add(new Movie("Побег из Шоушенка", "Стивен Кинг", 1994, 142, "Фрэнк Дарабонт"));
            movieLibrary.Add(new Movie("Крестный отец", "Марио Пьюзо", 1972, 175, "Фрэнсис Форд Коппола"));
            movieLibrary.Add(new Movie("Темный рыцарь", "Кристофер Нолан", 2008, 152, "Кристофер Нолан"));


            musicLibrary.Add(new MusicAlbum("Abbey Road", "The Beatles", 1969, "The Beatles", 17));
            musicLibrary.Add(new MusicAlbum("Thriller", "Michael Jackson", 1982, "Michael Jackson", 9));
            musicLibrary.Add(new MusicAlbum("Dark Side of the Moon", "Pink Floyd", 1973, "Pink Floyd", 10));
        }

        public static void ExportData()
        {
            Console.Clear();
            Console.WriteLine("ЭКСПОРТ ДАННЫХ");
            Console.WriteLine("1. Экспортировать все книги");
            Console.WriteLine("2. Экспортировать все фильмы");
            Console.WriteLine("3. Экспортировать все альбомы");
            Console.WriteLine("4. Экспортировать все медиа");
            Console.WriteLine("0. Назад");
            Console.Write("\nВыберите действие: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        bookLibrary.ExportToFile($"books_export.json");
                        break;
                    case "2":
                        movieLibrary.ExportToFile($"movies_export.json");
                        break;
                    case "3":
                        musicLibrary.ExportToFile($"music_export.json");
                        break;
                    case "4":
                        bookLibrary.ExportToFile($"all_books.txt");
                        movieLibrary.ExportToFile($"all_movies.txt");
                        musicLibrary.ExportToFile($"all_music.txt");
                        Console.WriteLine("Все данные экспортированы");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при экспорте: {ex.Message}");
            }
        }

    }
}
