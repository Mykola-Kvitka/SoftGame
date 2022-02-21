using System;
using SoftGame.Configuration;
using SoftGame.Skills.Interfaces;

namespace SoftGame.Units
{
    public class Warrior : IUnit
    {
        public int Health { get; protected set; }
        public int Attack{ get; protected set; }
        public override bool IsAlive => Health > 0;

        public Warrior()
        {
            Health = UnitsCoufiguration.WarriorHealth;
            Attack = UnitsCoufiguration.WarriorAttack;
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public override bool AttackTarget(IUnit warrior)
        {
            warrior.TakeDamage(Attack);
            return  warrior.IsAlive;
        }
    }
}