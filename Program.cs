using System;

namespace planetlogs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            App app = new App();
            //NOTE fires off app creation, creating all data and relationships
            app.Startup();
            //NOTE this starts the app and the console controls
            app.Run();
        }
    }
}
