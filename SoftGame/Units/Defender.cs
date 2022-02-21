using SoftGame.Configuration;

namespace SoftGame.Units
{
    public class Defender : Warrior
    {
        public int Defense { get; protected set; }

        public Defender()
        {
            Health = UnitsCoufiguration.DefenseHealth;
            Attack = UnitsCoufiguration.DefenseAttack;
            Defense = UnitsCoufiguration.DefenseDefense;
        }

        public override void TakeDamage(int damage)
        {
            damage -= Defense;

            if (damage > 0)
            {
                Health -= damage;
            }
        }
    }
}