using System;
using System.Collections.Generic;
using SoftGame.Battles;
using SoftGame.Units;
using Xunit;

namespace UnitTests
{
    public class OneByOneFights
    {
        [Theory]
        [MemberData(nameof(OneByOneFight))]
        public void Fights(Warrior warrior1, Warrior warrior2, bool shouldSucceed)
        {
            Assert.Equal(shouldSucceed, Battle.Fight(warrior1, warrior2));
        }
        
        public static IEnumerable<object[]> OneByOneFight()
        {
            yield return new object[] { new Warrior(), new Knight(), false };
            yield return new object[] { new Warrior(), new Warrior(), true };
            yield return new object[] { new Knight(), new Knight(), true };
        }

    }
}