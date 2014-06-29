namespace BattleField
{
    public interface IRenderer
    {
        void DrawGameField(string[,]field, int rows, int cols);

        void DrawGameStats();

        void DrawGameObjects();


    }
}
