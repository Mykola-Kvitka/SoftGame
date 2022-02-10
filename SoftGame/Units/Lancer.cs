using System;
using SoftGame.Skills.Interfaces;

namespace SoftGame.Units
{
    public class Lancer : Warrior
    {
        public int AttackToSecoundTarget = 0;

        private int _reduceDamage = 2;
        
        public Lancer()
        {
            Health = 50;
            Attack = 6;
        }

        public override bool AttackTarget(IUnit warrior)
        {
           var healthBeforeAttack =  warrior.Health;
                
            base.AttackTarget(warrior);

            if (warrior.IsAlive)
            {
                AttackToSecoundTarget = healthBeforeAttack - warrior.Health;
            }
            else
            {
                AttackToSecoundTarget = healthBeforeAttack + Math.Abs(warrior.Health);
            }

            AttackToSecoundTarget /= _reduceDamage;
            
            return warrior.IsAlive;
        }
    }
}