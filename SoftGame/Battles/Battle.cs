using System;
using SoftGame.Units;

namespace SoftGame.Battles
{
    public static class Battle
    {
        public static bool Fight(Warrior warrior1, Warrior warrior2)
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
    }
}