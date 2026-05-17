namespace PrakticeCSharp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tasker.Task1();
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}, исключение обработано");
            }
            
        }
    }
}
