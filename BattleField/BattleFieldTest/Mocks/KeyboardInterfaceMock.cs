using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleFieldTest.Mocks
{
    using BattleField.Interfaces;
    public abstract class KeyboardInterfaceMock : IKeyBoardInterfaceMock
    {
        private IEnumerable<int> singleIntegers;
        private IEnumerator<int> currentSingleElement;

        private IEnumerable<IEnumerable<int>> multipleIntegers;
        private IEnumerator<IEnumerable<int>> currentMultipleElements;

        public KeyboardInterfaceMock(IEnumerable<int> singleIntegers, IEnumerable<IEnumerable<int>> multipleIntegers)
        {
            this.singleIntegers = singleIntegers;
            this.multipleIntegers = multipleIntegers;
            this.currentSingleElement = singleIntegers.GetEnumerator();
            this.currentMultipleElements = multipleIntegers.GetEnumerator();
            this.GenerateUIMock();
        }

        public int GetNextSingleInteger()
        {
            if(!this.currentSingleElement.MoveNext())
            {
                throw new IndexOutOfRangeException("End of array reached.");
            }

            return this.currentSingleElement.Current;
        }

        public IEnumerable<int> GetNextMultileIntegers()
        {
            if (!this.currentMultipleElements.MoveNext())
            {
                throw new IndexOutOfRangeException("End of array reached.");
            }

            return this.currentMultipleElements.Current;
        }

        public IUserInterface UI { get; protected set; }

        public abstract void GenerateUIMock();
    }
}
