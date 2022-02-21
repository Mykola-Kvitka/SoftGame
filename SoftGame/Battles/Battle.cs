using System;
using System.Collections.Generic;
using System.Linq;
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
            var aliveUnitsArmy1 = army1.GetAllAliveUnits(u => u.IsAlive);
            var aliveUnitsArmy2 = army2.GetAllAliveUnits(u => u.IsAlive);

            while (aliveUnitsArmy1 != null && aliveUnitsArmy2 != null)
            {
                if (aliveUnitsArmy1.First().GetType() == typeof(Lancer))
                {
                    var lancer = (Lancer) aliveUnitsArmy1.First();
                    Fight(lancer, aliveUnitsArmy2, true);
                }
                else if (aliveUnitsArmy2.First().GetType() == typeof(Lancer))
                {
                    var lancer = (Lancer) aliveUnitsArmy2.First();
                    Fight(lancer, aliveUnitsArmy2, false);
                }
                else
                {
                    Fight(aliveUnitsArmy1.First(), aliveUnitsArmy2.First());
                }

                aliveUnitsArmy1 = army1.GetAllAliveUnits(u => u.IsAlive);
                aliveUnitsArmy2 = army2.GetAllAliveUnits(u => u.IsAlive);
            }

            return aliveUnitsArmy1 != null;
        }

        private static void Fight(Lancer warrior1, List<IUnit> army, bool IsFirstArmy)
        {
            if (IsFirstArmy)
            {
                while (warrior1.AttackTarget(army.First()) && army.First().AttackTarget(warrior1))
                {
                    if (army.Count > 1)
                    {
                        GiveDamageToSecoundWarrior(warrior1, army);
                    }
                }
            }
            else
            {
                while (army.First().AttackTarget(warrior1) && warrior1.AttackTarget(army.First()))
                {
                    if (army.Count > 1)
                    {
                        GiveDamageToSecoundWarrior(warrior1, army);
                    }
                }
            }
        }

        private static void GiveDamageToSecoundWarrior(Lancer warrior1, List<IUnit> army)
        {
            army[1].TakeDamage(warrior1.AttackToSecoundTarget);

            if (!army[1].IsAlive)
            {
                army.Remove(army[1]);
            }
        }
    }
}