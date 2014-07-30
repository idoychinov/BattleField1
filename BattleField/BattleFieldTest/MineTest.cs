namespace BattleFieldTest
{
    using System;
    using BattleField;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MineTest
    {
        private MineFactory factory;

        [TestInitialize]
        public void CreateFactory()
        {
            this.factory = new MineFactory();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AssigningMineStrengthLessThanOneShouldThrowAnException()
        {
            this.factory.CreateMine(new Position(1, 1), 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AssigningMineStrengthMoreThanFiveShouldThrowAnException()
        {
            this.factory.CreateMine(new Position(1, 1), 6);
        }
    }
}