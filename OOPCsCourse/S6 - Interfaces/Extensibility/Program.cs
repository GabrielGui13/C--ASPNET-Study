using System;
using System.IO;

namespace Extensibility
{
    class Program
    {
        public static void Main (string[] args) {
            // var dbMigrator = new DbMigrator(new ConsoleLogger());
            var dbMigrator = new DbMigrator(new FileLogger("C:\\Users\\gabri\\Desktop\\log.txt"));
            dbMigrator.Migrate();

            // Create a StreamReader from a FileStream  
            using (StreamReader reader = new StreamReader(new FileStream("C:\\Users\\gabri\\Desktop\\log.txt", FileMode.Open))) { 	string line;  
                // Read line by line  
                while ((line = reader.ReadLine()) != null) {  
                    Console.WriteLine(line);  
                }  
            }
        }
    }
}
