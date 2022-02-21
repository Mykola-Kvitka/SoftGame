using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SoftGame.Skills.Interfaces;
using SoftGame.Units;

namespace SoftGame
{
    public class Army
    {
        private List<IUnit> _army = new List<IUnit>();

        public void AddUnits<T>(T unit, int count)
        {
            _army.AddRange(ArmyFactory.UnitsFactoryGeneric(unit,count));
        }

        public List<IUnit> GetAllAliveUnits(Func<IUnit, bool> predicate)
        {
            return _army.Where(predicate).ToList();
        }
    }
}