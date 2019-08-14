namespace planetlogs.Models
{
    class Moon : Location
    {
        //NOTE: methods that are private only can be accessed from inside the class
        private Planet Home { get; set; }
        public void SetHome(Planet planet)
        {
            Home = planet;
        }

        public Moon(string name, Planet home) : base(name)
        {
            Home = home;
        }
    }
}
