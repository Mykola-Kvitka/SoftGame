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
                return UnitsFactory(unit as IUnit, count);
            }
            
            return new List<IUnit>();;
        }
        
        private static IEnumerable<IUnit> UnitsFactory(IUnit unit, int count)
        {
            var warriors = new List<IUnit>();
            
            for (int i = 0; i < count; i++)
            {
                warriors.Add((IUnit) unit.Clone());
            }

            return warriors;
        }
        private static List<IUnit> UnitsFactory(string unit, int count)
        {
            switch (unit)
            {
                case "Warrior":
                    return (List<IUnit>) UnitsFactory(new Warrior(), count);
                case "Knight":
                    return (List<IUnit>) UnitsFactory(new Knight(), count);
                default:
                    return new List<IUnit>();
            } 
        }
    }
}