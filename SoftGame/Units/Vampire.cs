using System;
using SoftGame.Configuration;
using SoftGame.Skills.Interfaces;

namespace SoftGame.Units
{
    public class Vampire : Warrior
    {
        public double Vampirism { get; protected set; }

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
            
            base.AttackTarget(warrior);

            if (warrior.IsAlive)
            {
                heal = (double)(healthBeforeAttack - warrior.Health) / 100.0d * Vampirism;
            }
            else
            {
                heal =  (double)healthBeforeAttack / 100.0d * Vampirism;
            }

            Health += (int)Math.Round(heal);
            
            if (Health > UnitsCoufiguration.VampireHealth)
            {
                Health = UnitsCoufiguration.VampireHealth;
            }

            return warrior.IsAlive;
        }
    }
}