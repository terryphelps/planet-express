using System;
using planetlogs.Models;

namespace planetlogs
{
    class App
    {
        public Planet CurrentPlanet { get; set; }
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

            //NOTE Create Planet Relationships, building each connection
            mercury.Next(venus);
            // venus.Previous(mercury);
            venus.Next(earth);
            // earth.Previous(venus);
            earth.Next(mars);
            mars.Next(jupiter);
            jupiter.Next(saturn);
            saturn.Next(uranus);
            uranus.Next(neptune);
            neptune.Next(pluto);

            //Set Active Planet
            CurrentPlanet = mercury;
        }

        //NOTE runs app
        public void Run()
        {
            while (Running)
            {
                System.Console.WriteLine($"Welcome to {CurrentPlanet.Name}");
                System.Console.WriteLine("What do you want to do?");

                //NOTE LOOK AT ME TOMORROW  ("go next", "quit", "go {Moon.name}", "go home", "sign" )

                //NOTE takes in the input and splits into array of strings based on space character
                string[] input = Console.ReadLine().ToLower().Split(' ');
                string command = input[0];
                string option = "";
                if (input.Length > 1)
                {
                    option = input[1];
                }

                switch (command)
                {
                    case "go":
                        Go(option);
                        break;
                    case "quit":
                        Running = false;
                        break;
                    case "sign":
                        break;
                    default:
                        System.Console.WriteLine("Unknown Command");
                        break;
                }
            }

        }

        private void Go(string option)
        {
            CurrentPlanet = CurrentPlanet.Go(option);
        }
    }
}