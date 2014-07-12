using System.Collections.Generic;
namespace BattleField
{
    public interface IUserInterface
    {
        int ReadInteger();
        IEnumerable<int> ReadMultipleIntegers(int count);
    }
}
