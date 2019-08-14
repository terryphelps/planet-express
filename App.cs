using System;
using System.Threading;
using planetlogs.Models;

namespace planetlogs
{
    class App
    {
        public Location CurrentLocation { get; set; }
        private bool Running { get; set; } = true;

        //NOTE creates all data and relationships
        public void Startup()
        {
            //Create All Planets
            Planet mercury = new Planet("Mercury");
            Planet venus = new Planet("Venus");
            Planet earth = new Planet("Earth");
            Planet mars = new Planet("Mars");
            Planet jupiter = new Planet("Jupiter");
            Planet saturn = new Planet("Saturn");
            Planet uranus = new Planet("Uranus");
            Planet neptune = new Planet("Neptune");
            Planet pluto = new Planet("Pluto");
            Moon luna = new Moon("Luna");
            // earth.AddMoon(luna);
            //NOTE the planet will notifiy the moon that it is the parent 
            //       see Planet.cs line 30

            //NOTE Create Planet Relationships, building each connection
            // mercury.Next(venus);
            //NOTE this now occurs inside the Next method
            //       line 38 in Planet.cs venus.Previous(mercury)
            // venus.Next(earth);
            // earth.Next(mars);
            // mars.Next(jupiter);
            // jupiter.Next(saturn);
            // saturn.Next(uranus);
            // uranus.Next(neptune);
            // neptune.Next(pluto);


            //Establish Relationships
            mercury.AddLocation("next", venus);
            mercury.AddLocation("previous", luna);
            venus.AddLocation("previous", mercury);
            venus.AddLocation("next", earth);
            earth.AddLocation("previous", venus);
            earth.AddLocation("luna", luna);
            luna.AddLocation("home", earth);
            earth.AddLocation("next", mars);
            mars.AddLocation("previous", earth);
            mars.AddLocation("next", jupiter);
            jupiter.AddLocation("previous", mars);

            //Set Active Planet
            CurrentLocation = earth;
        }

        //NOTE runs app
        public void Run()
        {
            while (Running)
            {
                //NOTE this is an auto fail
                for (int i = 0; i < 10; i++)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    Ship();
                    Console.Beep();
                    Thread.Sleep(10);
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    Ship();
                    Console.Beep();
                }
                Console.Clear();
                string greet = $"Welcome to {CurrentLocation.Name}";
                foreach (char letter in greet)
                {
                    Console.Write(letter);
                    Thread.Sleep(100);
                    Console.BackgroundColor = ConsoleColor.White;
                    Thread.Sleep(100);
                }

                System.Console.WriteLine("");
                System.Console.Write("Destinations Available: ");
                CurrentLocation.PrintDirections();
                if (CurrentLocation is Planet)
                {
                    var CurrentPlanet = (Planet)CurrentLocation;
                    CurrentPlanet.PrintGuestBook();
                }
                System.Console.Write("What do you want to do: ");

                //NOTE LOOK AT ME TOMORROW  ("go next", "quit", "go {Moon.name}", "go home", "sign" )

                //NOTE takes in the input and splits into array of strings based on space character 

                //                  input = ['go', 'luna']
                string[] input = Console.ReadLine().ToLower().Split(' ');
                Console.Clear();
                string command = input[0]; //command = 'go'
                string option = ""; //option = ''
                if (input.Length > 1)
                {
                    option = input[1]; //option = 'luna'
                }
                //          'go'
                switch (command)
                {
                    case "go":
                        Go(option); // 'luna'
                        break;
                    case "quit":
                        Running = false;
                        break;
                    case "sign":
                        Sign();
                        break;
                    default:
                        System.Console.WriteLine("Unknown Command");
                        break;
                }
            }

        }

        private void Sign()
        {
            //NOTE: 'is' is a type checker
            if (CurrentLocation is Planet)
            {
                var CurrentPlanet = (Planet)CurrentLocation;
                System.Console.Write("What is your name: ");
                string name = Console.ReadLine();
                CurrentPlanet.GuestBook.Add(name);
                System.Console.WriteLine("Signed as: " + name);
                return;
            }
            System.Console.WriteLine("No GuestBook here");
        }

        private void Go(string option) //option = 'luna'
        {                   //{Location: Luna}
            CurrentLocation = CurrentLocation.Go(option);
        }

        private void Ship()
        {
            Console.WriteLine(@"
                     `. ___
                    __,' __`.                _..----....____
        __...--.'``;.   ,.   ;``--..__     .'    ,-._    _.-'
  _..-''-------'   `'   `'   `'     O ``-''._   (,;') _,'
,'________________                          \`-._`-','
 `._              ```````````------...___   '-.._'-:
    ```--.._      ,.                     ````--...__\-.
            `.--. `-`                       ____    |  |`
              `. `.                       ,'`````.  ;  ;`
                `._`.        __________   `.      \'__/`
                   `-:._____/______/___/____`.     \  `
                               |       `._    `.    \
                               `._________`-.   `.   `.___
                                                  `------'`
            
            ");
        }
    }
}