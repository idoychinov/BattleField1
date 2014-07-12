namespace BattleField
{
    public interface IGameField
    {
        GameObject GetObjectAtPosition(Position position);
        int Size { get; }
    }
}