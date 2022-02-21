using System;
using System.Linq;
using SoftGame.Battles;
using SoftGame.Enums;
using SoftGame.Units;

namespace SoftGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new Army();
            first.AddUnits(new Warrior(), 20);
            var s = new Army();
            s.AddUnits(new Warrior(), 21);

            Console.WriteLine(Battle.Fight(first,s));
            Battle.Fight(first,s);
        }
    }
}