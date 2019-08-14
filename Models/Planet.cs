using System.Collections.Generic;

namespace planetlogs.Models
{
    class Planet : Location
    {
        public Planet NextPlanet { get; set; }
        public Planet PreviousPlanet { get; set; }
        public List<Moon> Moons { get; set; }

        public Planet(string name) : base(name)
        {
            Moons = new List<Moon>();

        }
    }







}