using System;
using SoftGame.Battles;
using SoftGame.Units;

namespace SoftGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Battle.Fight(new Warrior(), new Warrior()));
        }
    }
}