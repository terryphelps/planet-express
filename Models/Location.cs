using System;
using System.Collections.Generic;
using System.Threading;

namespace planetlogs.Models
{
  abstract class Location
  {
    public string Name { get; set; }

    //NOTE collection of directions and the location they take you to
    private Dictionary<string, Location> Directions { get; set; }

    public void AddLocation(string direction, Location locationObject)
    {
      Directions.Add(direction, locationObject);
      //directions = {
      //"next" = {Location}
      //}



      // switch (direction)
      // {
      //     case "north":
      //         locationObject.AddLocation("south", this);
      //         break;
      // }
    }

    public Location Go(string direction) //next, prev, {moon.Name}
    {
      if (Directions.ContainsKey(direction))
      {
        Console.WriteLine("Traveling....");
        Thread.Sleep(300);
        Console.Clear();
        return Directions[direction];
      }
      Console.WriteLine("can't go that way");
      Thread.Sleep(2000);
      return this;
    }

    public Location(string name)
    {
      Name = name;
      Directions = new Dictionary<string, Location>();
    }

    public void PrintDirections()
    {
      foreach (var location in Directions)
      {
        System.Console.Write(location.Key + ", ");
      }
      System.Console.WriteLine("");
    }
  }

}