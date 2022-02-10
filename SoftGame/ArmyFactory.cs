using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using SoftGame.Enums;
using SoftGame.Skills.Interfaces;
using SoftGame.Units;

namespace SoftGame
{
    public static class ArmyFactory
    {
        public static IEnumerable<IUnit> UnitsFactoryGeneric<T>(T unit, int count)
        {
            Type type = unit.GetType();
            
            if (type.Name == "String")
            {
                return UnitsFactory(unit as string, count);
            }
            else if(type.IsEnum)
            {
                return UnitsFactory(type.GetEnumName(unit), count);
            }
            else if (type.IsClass)
            {
                return UnitsFactory(type.Name, count);
            }
            
            return new List<IUnit>();;
        }
        
        private static List<IUnit> UnitsFactory(string unit, int count)
        {
            var warriors = new List<IUnit>();

            switch (unit)
            {
                case "Warrior":
                    for (int i = 0; i < count; i++)
                    {
                        warriors.Add(new Warrior());
                    }
                    break;
                case "Knight":
                    for (int i = 0; i < count; i++)
                    {
                        warriors.Add(new Knight());
                    }
                    break;
                case "Vampire":
                    for (int i = 0; i < count; i++)
                    {
                        warriors.Add(new Vampire());
                    }
                    break;

                default:
                    throw new ArgumentException("This class don`t implement at this fabric");
                    break;
            } 
            return warriors;
        }
    }
}