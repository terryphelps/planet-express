using System.Collections.Generic;

namespace planetlogs.Models
{
    class Planet : Location
    {
        Planet NextPlanet { get; set; }
        Planet PreviousPlanet { get; set; }
        List<Moon> Moons { get; set; }
        public void AddMoon(Moon moon)
        {
            Moons.Add(moon);
        }

        public Planet(string name) : base(name)
        {
            Moons = new List<Moon>();

        }
    }







}