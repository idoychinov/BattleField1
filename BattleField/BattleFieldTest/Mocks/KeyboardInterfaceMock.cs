namespace BattleFieldTest.Mocks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BattleField.Interfaces;

    public abstract class KeyboardInterfaceMock : IKeyBoardInterfaceMock
    {
        // private readonly IEnumerable<int> singleIntegers;
        private readonly IEnumerator<int> currentSingleElement;

        // private readonly IEnumerable<IEnumerable<int>> multipleIntegers;
        private readonly IEnumerator<IEnumerable<int>> currentMultipleElements;
        
        public KeyboardInterfaceMock(IEnumerable<int> singleIntegers, IEnumerable<IEnumerable<int>> multipleIntegers)
        {
            // this.singleIntegers = singleIntegers;
            // this.multipleIntegers = multipleIntegers;
            this.currentSingleElement = singleIntegers.GetEnumerator();
            this.currentMultipleElements = multipleIntegers.GetEnumerator();
            this.GenerateUIMock();
        }
        
        public IUserInterface UI { get; protected set; }

        public int GetNextSingleInteger()
        {
            if (!this.currentSingleElement.MoveNext())
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

        public abstract void GenerateUIMock();
    }
}
