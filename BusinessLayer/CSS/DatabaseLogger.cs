namespace BusinessLayer.CSS
{
    public class DatabaseLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Veritabanına Loglandı");
        }
    }

}
