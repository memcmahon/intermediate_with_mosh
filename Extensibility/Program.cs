using System;
using System.IO;

namespace Extensibility
{
    public interface ILogger
    {
        void LogError(string message);
        void LogInfo(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.WriteLine(message);
        }

        public void LogInfo(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogger
    {
        private readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }
           
        public void LogError(string message)
        {
            Log(message, "ERROR");
        }

        public void LogInfo(string message)
        {
            Log(message, "INFO");
        }

        private void Log(string message, string messageType)
        {
            var streamWriter = new StreamWriter(_path, true);
            streamWriter.WriteLine(messageType + ": " + message);
            // CLR does not manage file resource, so we need to manually dispose that resource. You can do it with the Dispose method, or a using block.
            streamWriter.Dispose();

            // the keyword `using` automatically includes a `Dispose()` call.
            //using (var streamWriter = new StreamWriter(_path, true))
            //{
            //    streamWriter.WriteLine(message);
            //}
        }
    }

    public class DbMigrator
    {
        private readonly ILogger _logger;

        public DbMigrator(ILogger logger)
        {
            _logger = logger;
        }

        public void Migrate()
        {
            _logger.LogInfo("Migration started at: " + DateTime.Now.ToLongTimeString());

            for(var i = 0; i < 1000000000; i++)
            {
                var num = 1 + 1;
            }

            _logger.LogInfo("Migration finished at " + DateTime.Now.ToLongTimeString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new FileLogger("/Users/megan/Projects/IntermediateWithMosh/log.txt");
            var migrator = new DbMigrator(logger);

            migrator.Migrate();

            
        }
    }
}
