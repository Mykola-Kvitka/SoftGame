using SoftGame.Configuration;
using SoftGame.Skills.Interfaces;

namespace SoftGame.Units
{
    public class Warrior : IUnit
    {
        protected int Health;
        protected double Attack;
        public bool IsAlive => Health > 0;

        int IUnit.Health
        {
            get => Health;
            set => Health = value;
        }

        double IUnit.Attack
        {
            get => Attack;
            set => Attack = value;
        }
        
        public Warrior()
        {
            Health = UnitsCoufiguration.WarriorHealth;
            Attack = UnitsCoufiguration.WarriorAttack;
        }

        public virtual void TakeDamage(double damage)
        {
            Health -= (int)damage;
        }

        public virtual bool AttackTarget(IUnit warrior)
        {
            warrior.TakeDamage(Attack);
            return  warrior.IsAlive;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}