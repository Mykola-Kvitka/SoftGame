using SoftGame.Configuration;
using SoftGame.Skills.Interfaces;

namespace SoftGame.Units
{
    public class Warrior : IUnit
    {
        protected int Health;
        protected int Attack;
        public bool IsAlive => Health > 0;

        int IUnit.Health
        {
            get => Health;
            set => Health = value;
        }

        int IUnit.Attack
        {
            get => Attack;
            set => Attack = value;
        }
        
        public Warrior()
        {
            Health = UnitsCoufiguration.WarriorHealth;
            Attack = UnitsCoufiguration.WarriorAttack;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public virtual bool AttackTarget(IUnit warrior)
        {
            warrior.TakeDamage(Attack);
            return  warrior.IsAlive;
        }
    }
}