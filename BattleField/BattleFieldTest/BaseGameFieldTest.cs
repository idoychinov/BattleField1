namespace BattleFieldTest
{
    using System;
    using BattleField;
    using BattleField.Interfaces;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BaseGameFieldTest
    {
        [TestMethod]
        public void TestAddObjectAtPosition()
        {
            IGameField field = new BaseGameField(5, new BaseMinePlacer());
            IPosition position = new Position(0, 0);
            IGameObject destroyedField = new DestroyedField(position);
            field.AddObjectToAllObjects(destroyedField);
            Assert.AreEqual(destroyedField, field.GetObjectAtPosition(position));
        }
    }
}