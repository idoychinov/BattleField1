namespace BattleFieldTest
{
    using BattleField;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        public void PositionEqualityShoudWork()
        {
            var position1 = new Position(1, 1);
            var position2 = new Position(1, 1);
            Assert.AreEqual(position1, position1);
        }

        [TestMethod]
        public void PositionUnequalityShouldWork()
        {
            var position1 = new Position(1, 1);
            var position2 = new Position(1, 2);
            Assert.AreNotEqual(position1, position2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowExceptionIfNegativeXIsAssigned()
        {
            var position = new Position(-1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowExceptionIfNegativeYIsAssigned()
        {
            var position = new Position(1, -1);
        }
    }
}