using System.Collections.Generic;
using SoftGame;
using SoftGame.Battles;
using SoftGame.Skills.Interfaces;
using SoftGame.Units;
using Xunit;

namespace UnitTests
{
    public class FightsBetwenArmyTest
    {
        [Theory]
        [MemberData(nameof(ArmyAgaintsArmy))]
        public void Fights(Army army1, Army army2, bool shouldSucceed,
            int army1count ,Warrior init1 ,int army2count , Warrior init2)
        {
            army1.AddUnits(init1,army1count);
            army2.AddUnits(init2,army2count);
            
            Assert.Equal(shouldSucceed, Battle.Fight(army1, army2));
        }
        
        public static IEnumerable<object[]> ArmyAgaintsArmy()
        {
            yield return new object[] { new Army(), new Army(), false , 1 , new Warrior() , 2, new Warrior() };
            yield return new object[] { new Army(), new Army(), false , 2 , new Warrior() , 3, new Warrior()};
            yield return new object[] { new Army(), new Army(), false , 5 , new Warrior() , 7, new Warrior()};
            yield return new object[] { new Army(), new Army(), true , 10 , new Warrior() , 11, new Warrior()};
            yield return new object[] { new Army(), new Army(), true , 11 , new Warrior() , 7, new Warrior()};
            yield return new object[] { new Army(), new Army(), true , 20 , new Warrior() , 21, new Warrior()};
        }
    }
}