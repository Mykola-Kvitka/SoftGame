using System;

namespace SoftGame.Skills.Interfaces
{
    public interface IUnit : IAttacker, IDamageable
    {
        public int Health {  get; protected set; }
        public int Attack { protected set; get; }

        public bool IsAlive => Health > 0;

    }
}