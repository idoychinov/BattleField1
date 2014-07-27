using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
namespace BattleFieldTest.Mocks
{
    using BattleField.Interfaces;
    class MoqKeyboardInterfaceMock : KeyboardInterfaceMock, IKeyBoardInterfaceMock
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
