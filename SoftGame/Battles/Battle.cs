using System;
using SoftGame.Skills.Interfaces;
using SoftGame.Units;

namespace SoftGame.Battles
{
    public static class Battle
    {
        public static bool Fight(IUnit warrior1, IUnit warrior2)
        {
            while (true)
            {
                if (!warrior1.AttackTarget(warrior2))
                {
                    return warrior1.IsAlive;
                }

                if (!warrior2.AttackTarget(warrior1))
                {
                    return warrior1.IsAlive;
                }
            }
        }

        public static bool Fight(Army army1, Army army2)
        {
            var aliveUnitsArmy1Enumerator = army1.GetAllAliveUnits().GetEnumerator();
            var aliveUnitsArmy2Enumerator = army2.GetAllAliveUnits().GetEnumerator();

            using (aliveUnitsArmy1Enumerator)
            using (aliveUnitsArmy2Enumerator)
            {
                aliveUnitsArmy1Enumerator.MoveNext();
                aliveUnitsArmy2Enumerator.MoveNext();
                
                while (aliveUnitsArmy1Enumerator.Current != null &&
                        aliveUnitsArmy2Enumerator.Current != null )
                {
                    if (Fight(aliveUnitsArmy1Enumerator.Current, aliveUnitsArmy2Enumerator.Current))
                    {
                        aliveUnitsArmy2Enumerator.MoveNext();
                    }
                    else
                    {
                        aliveUnitsArmy1Enumerator.MoveNext();
                    }
                }

                if (aliveUnitsArmy1Enumerator.Current == null)
                {
                    return false;
                }
                else if(aliveUnitsArmy2Enumerator.Current == null)
                {
                    return true;
                }
                else
                {
                    throw new Exception("Draw");
                }
            }
        }
    }
}