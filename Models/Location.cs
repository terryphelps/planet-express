using System.Collections.Generic;

namespace planetlogs.Models
{
    abstract class Location
    {
        public string Name { get; set; }
        public List<string> GuestBook { get; set; }
        public Location(string name)
        {
            Name = name;
            GuestBook = new List<string>();
        }
    }

}