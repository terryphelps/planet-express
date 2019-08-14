using System;
using System.Collections.Generic;

namespace planetlogs.Models
{
    //NOTE 'this' is always the class instance
    class Planet : Location
    {
        public List<string> GuestBook { get; set; }

        #region Old way
        // Planet NextPlanet { get; set; }
        // Planet PreviousPlanet { get; set; }
        // List<Moon> Moons { get; set; }
        // public Location Go(string direction) //direction = 'next'
        // {
        //     if (direction == "next")
        //     {
        //         return NextPlanet; //{Mars}
        //     }
        //     else if (direction == "previous")
        //     {
        //         return PreviousPlanet;
        //     }
        //     else
        //     {
        //         Moon destination = Moons.Find(m => m.Name.ToLower() == direction);
        //         return destination;
        //     }
        //     System.Console.WriteLine("can't go that way");
        //     return this;
        // }

        // public void AddMoon(Moon m)
        // {
        //     Moons.Add(m);
        //     //NOTE 'this' is always a refrence to the object that it is inside of currently (PLANET)
        //     m.SetHome(this);
        // }

        //NOTE this method adds the next planet
        // public void Next(Planet planet)
        // {
        //     NextPlanet = planet;
        //     //NOTE 'this' is always a refrence to the object that it is inside of currently (PLANET)
        //     planet.Previous(this);
        // }
        //NOTE this method adds the previous planet
        // public void Previous(Planet planet)
        // {
        //     PreviousPlanet = planet;
        // }
        #endregion


        public Planet(string name) : base(name)
        {
            // Moons = new List<Moon>();
            GuestBook = new List<string>();
        }

        public void PrintGuestBook()
        {
            System.Console.WriteLine("Previous Visitors:");
            GuestBook.ForEach(name =>
            {
                System.Console.WriteLine(name);
            });
        }
    }







}