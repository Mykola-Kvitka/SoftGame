using SoftGame.Configuration;

namespace SoftGame.Units
{
    public class Knight : Warrior
    {
        public Knight()
        {
            Health = UnitsCoufiguration.KnightHealth;
            Attack = UnitsCoufiguration.KnightAttack;
        }
    }
}