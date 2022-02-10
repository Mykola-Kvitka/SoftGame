using System;
using SoftGame.Configuration;
using SoftGame.Skills.Interfaces;

namespace SoftGame.Units
{
    public class Vampire : Warrior
    {
        public int Vampirism { get; protected set; }

        public Vampire()
        {
            Health = UnitsCoufiguration.VampireHealth;
            Attack = UnitsCoufiguration.VampireAttack;
            Vampirism = UnitsCoufiguration.VampireVampirism;
        }

        public override bool AttackTarget(IUnit warrior)
        {
            double heal;
            var healthBeforeAttack = warrior.Health;
            
            warrior.TakeDamage(Attack);

            if (warrior.IsAlive)
            {
                heal = (double)(healthBeforeAttack - warrior.Health) / 100.0d * (double)Vampirism;
            }
            else
            {
                heal = healthBeforeAttack / 100 * Vampirism;
            }

            Health += (int)Math.Round(heal);
            
            if (Health > 40)
            {
                Health = 40;
            }

            return warrior.IsAlive;
        }
    }
}