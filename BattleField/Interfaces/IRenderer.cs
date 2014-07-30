namespace BattleField.Interfaces
{
    public interface IRenderer
    {
        void DrawGameField(IGameField field);

        void PrintMessage(string message);
    }
}