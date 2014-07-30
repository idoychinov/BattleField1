namespace BattleFieldTest
{
    using System;
    using BattleField;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void PositionEqualityShoudWork()
        {
            var position1 = new Position(1, 1);
            var position2 = new Position(1, 1);
            Assert.AreEqual(position1, position2);
        }

        [TestMethod]
        public void PositionUnequalityShouldWork()
        {
            var position1 = new Position(1, 1);
            var position2 = new Position(1, 2);
            Assert.AreNotEqual(position1, position2);
        }
    }
}