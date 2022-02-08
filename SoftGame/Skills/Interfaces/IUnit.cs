using System;

namespace SoftGame.Skills.Interfaces
{
    public interface IUnit : IAttacker, IDamageable,ICloneable
    {
        public int Health {  get; protected set; }
        public double Attack { protected set; get; }

        public bool IsAlive => Health > 0;

    }
}