namespace BattleField.Interfaces
{
    using System.Collections.Generic;

    public interface IUserInterface
    {
        int ReadInteger();
        IEnumerable<int> ReadMultipleIntegers(int count);
    }
}
