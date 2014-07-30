namespace BattleFieldTest.Mocks
{
    using System;
    using System.Collections.Generic;
    using BattleField.Interfaces;
    using Moq;

    public class MoqKeyboardInterfaceMock : KeyboardInterfaceMock, IKeyBoardInterfaceMock
    {
        public MoqKeyboardInterfaceMock(IEnumerable<int> singleIntegers, IEnumerable<IEnumerable<int>> multipleIntegers)
            : base(singleIntegers, multipleIntegers)
        {
        }

        public override void GenerateUIMock()
        {
            var mock = new Mock<IUserInterface>();
            mock.Setup(ui => ui.ReadInteger()).Returns(this.GetNextSingleInteger());
            mock.Setup(ui => ui.ReadMultipleIntegers(It.IsAny<int>())).Returns(this.GetNextMultileIntegers());
            this.UI = mock.Object;
        }
    }
}
