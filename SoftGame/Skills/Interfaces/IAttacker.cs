using SoftGame.Units;

namespace SoftGame.Skills.Interfaces
{
    public interface IAttacker
    {
        public bool AttackTarget(IUnit warrior);
    }
}