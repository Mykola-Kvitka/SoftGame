using System;

namespace SoftGame.Skills.Interfaces
{
    public abstract class IUnit : IAttacker, IDamageable
    {
        public int Health;
        public int Attack;
        public virtual bool IsAlive => Health > 0;
        public abstract bool AttackTarget(IUnit warrior);
        public abstract void TakeDamage(int damage);
    }
}