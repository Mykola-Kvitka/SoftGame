﻿using SoftGame.Configuration;
using SoftGame.Skills.Interfaces;

namespace SoftGame.Units
{
    public class Warrior : IAttacker, IDamageable
    {
        protected double Health;
        protected double Attack;

        public bool IsAlive => Health > 0;

        public Warrior()
        {
            Health = UnitsCoufiguration.WarriorHealth;
            Attack = UnitsCoufiguration.WarriorAttack;
        }

        public virtual void TakeDamage(double damage)
        {
            Health -= damage;
        }

        public virtual bool AttackTarget(Warrior warrior)
        {
            warrior.TakeDamage(Attack);
            return  warrior.IsAlive;
        }
    }
}