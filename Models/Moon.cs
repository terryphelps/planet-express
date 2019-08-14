namespace planetlogs.Models
{
    class Moon : Location
    {
        public Planet Home { get; set; }

        public Moon(string name, Planet home) : base(name)
        {
            Home = home;
        }
    }
}
