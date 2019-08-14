using System;

namespace planetlogs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Solar System!");
            App app = new App();
            //NOTE fires off app creation, creating all data and relationships
            app.Startup();
            app.Run();
        }
    }
}
