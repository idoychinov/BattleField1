namespace BattleField.Interfaces
{
    public interface IRenderer
    {
        void DrawGameField(IGameField field);

        void DrawGameStats();

        void DrawGameObjects();

        void PrintMessage(string message);
    }
}