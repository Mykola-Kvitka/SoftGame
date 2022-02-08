using System.Collections.Generic;
using System.Linq;
using SoftGame.Skills.Interfaces;
using SoftGame.Units;

namespace SoftGame
{
    public class Army
    {
        private List<IUnit> _army = new List<IUnit>();

        public void AddUnits<T>(T unit, int count) where T : new()
        {
            _army.AddRange(ArmyFactory.UnitsFactoryGeneric(unit,count));
        }

        public List<IUnit> GetAllAliveUnits()
        {
            return _army.Where(unit => unit.IsAlive).ToList();
        }
    }
}